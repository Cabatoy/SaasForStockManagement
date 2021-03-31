using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcUICore.Utility.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Entities.Dtos;

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

            if (result != null)
            {
                HttpContext.Session.SetInt32("token", 1);
                HttpContext.Session.SetString("fullname", "b");
                return Redirect("/Home/Index");
            }

            return View();
        }


        public IActionResult LogOut()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
