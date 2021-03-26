using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace WebCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
    
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _companyService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }
     
        [HttpGet(template: "getById")]
        public IActionResult GetById(int companyId)
        {
            var result = _companyService.GetById(companyId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }


        [HttpPost(template: "add")]
        public IActionResult Add (Company company)
        {
            var result = _companyService.Add(company);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Company company)
        {
            var result = _companyService.Update(company);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(Company company)
        {
            var result = _companyService.Delete(company);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
    }
}
