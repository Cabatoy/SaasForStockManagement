using MvcUI.Utility.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MvcUI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {

            HttpService.Get("users", "getById", 5);
            
            
            HttpService.Get("users","getall");

            return View();
        }

        public ActionResult LogOut()
        {
            return View();
        }
    }
}