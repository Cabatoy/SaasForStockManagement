using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos;

namespace WebCoreApi.Controllers
{
    /// <summary>
    /// Login,Register system
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
      

        /// <summary>
        /// login-token-kullanıcı işlemleri.
        /// </summary>
        /// <param name="authService"></param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// giriş için jwt token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto user)
        {
            var userToLogin = _authService.Login(user);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        /// <summary>
        /// firmaya ait kullanıcı oluşturmak için kullanılır, firma ve local ıd dolu gönderilmeli
        /// manager kısmında kullanıcı daha önce mail adresiyle kayıt yapılmış mıdır diye kontrol edilir
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExist(userForRegisterDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var registerResult = _authService.Register(userForRegisterDto);
            if (registerResult.Success)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }
            return BadRequest(registerResult.Message);
        }

        /// <summary>
        /// ilk firma kaydı için kullanılır.
        /// companyid ve local id bos olur.kayit işleminden sonra dolar.
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <returns></returns>
        [HttpPost("registerForCompany")]
        public IActionResult RegisterForCompany(UserForRegisterDto userForRegisterDto)
        {
            var registerResult = _authService.RegisterForCompany(userForRegisterDto);
            if (registerResult.Success)
            {
                if (registerResult.Success)
                {
                    return Ok(registerResult);
                }
                return BadRequest(registerResult.Message);
            }
            return BadRequest(registerResult.Message);
        }
    }
}
