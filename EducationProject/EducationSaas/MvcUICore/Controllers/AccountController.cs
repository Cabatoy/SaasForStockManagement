using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcUICore.Utility.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Dtos;
using MvcUICore.Models;
using Microsoft.AspNetCore.Http;

namespace MvcUICore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
            //HttpService.Get("users", "getById", 5);
            //HttpService.Get("users", "getall");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            UserForLoginDto user = new UserForLoginDto { Email = email, Password = password };
           
            var result = HttpService.Post("Auth", "login", user);

            if (string.IsNullOrEmpty(result) || result.Equals("\"Kullanıcı veya Sifre Hatali\""))
            {
                HttpContext.Session.SetString("login", "0");
                return RedirectToAction("Login");                
            }
            else
            {
                HttpContext.Session.SetString("login", "1");
                return Redirect("/Home/Index");
            }
        }


        public IActionResult LogOut()
        {
            return View();
        }

        public IActionResult Register()
        {           
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var result = HttpService.Post("Auth", "register", userForRegisterDto);
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
