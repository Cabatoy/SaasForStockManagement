using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcUICore.Utility.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUICore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();

            Users user = new Users { Id = 1, FullName = "berat", CompanyId = 1 };

            HttpService.Post("users", "add", user);

            HttpService.Get("users", "getById", 5);

            HttpService.Get("users", "getall");


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
