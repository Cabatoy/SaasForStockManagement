using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcUICore.Utility.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUICore.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            List<Company> companies = new List<Company>();
            var result = HttpService.Get("companies", "getall");
            companies = JsonConvert.DeserializeObject<List<Company>>(result);
            return View(companies);
        }
        [HttpPost]
        public IActionResult Index(Company company)
        {
            var result = HttpService.Post("companies", "add", company);
            return Redirect("index");
        }

        [HttpPost]
        public IActionResult Update(int id,string name, int taxno,string adress)
        {
            return Json(new { result = 1, message = "Başarılı." });
            //var result = HttpService.Post("companies", "add", company);
            //return Redirect("index");
        }
    }
}
