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
            //var httpHandler = new HttpClientHandler();
            //httpHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            //{
            //    return true;
            //};

            //using (var client = new HttpClient(httpHandler))
            //{
            //    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

            //    client.BaseAddress = new Uri("https://localhost:44329/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage response;
            //    response = client.GetAsync("api/users/getall").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //    }
            //    else
            //    {
            //    }
            //}

            HttpService.Get("users","getall");



            return View();
        }

        public ActionResult LogOut()
        {
            return View();
        }
    }
}