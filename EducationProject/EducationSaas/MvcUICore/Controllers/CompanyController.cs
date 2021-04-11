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
        public IActionResult Update(int id, string name, int taxno, string adress)
        {
            Company company = new Company();
            company.Id = id;
            company.FullName = name;
            company.TaxNumber = taxno.ToString();
            company.Adress = adress;

            var result = HttpService.Update("companies", "update", company);           

            return Json(new { result = 1, message = result });
        }

        [HttpPost]
        public IActionResult Delete(int id, string name, int taxno, string adress)
        {
            //buralar bi düzenlenecek
            //sadece id gönderirsek, bu şekilde company modeli çekmemiz gerek veya- model göndermeye bakmak lazım.,
            var result = HttpService.Get("companies", "getById", id);
            var company = JsonConvert.DeserializeObject<Company>(result);

            //company model göndermede sorun yaşadım,(DeleteAsync) ,
            HttpService.Delete("companies", "delete", id);
            return Json(new { result = 1, message = "Başarılı." });
        }
    }
}
