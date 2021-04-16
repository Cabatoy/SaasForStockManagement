using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace WebCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Take All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _userService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }


        /// <summary>
        /// Take User With Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //[HttpGet(template: "getById")]
        [HttpGet]
        [Route("GetById/{userId:int}")]
        public IActionResult GetById(int userId)
        {
            var result = _userService.GetById(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        #region pasif

        //[HttpPost(template: "add")]
        //public IActionResult Add(User user)
        //{
        //    var result = _userService.Add(user);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    else
        //        return BadRequest(result.Message);
        //}

        //[HttpPost(template: "update")]
        //public IActionResult Update(User user)
        //{
        //    var result = _userService.Update(user);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    else
        //        return BadRequest(result.Message);
        //}
        //[HttpPost(template: "delete")]
        //public IActionResult Delete(User user)
        //{
        //    var result = _userService.Delete(user);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    else
        //        return BadRequest(result.Message);
        //} 
        #endregion
    }
}
