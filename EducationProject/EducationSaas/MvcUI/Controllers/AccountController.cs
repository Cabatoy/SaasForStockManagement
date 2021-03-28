using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUI.Controllers
{
    public class AccountController : Controller
    {
       public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult LogOut()
        {
            return View();
        }
    }
}