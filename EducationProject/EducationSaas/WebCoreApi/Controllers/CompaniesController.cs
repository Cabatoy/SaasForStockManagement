using Business.Abstract;
using Core.Extensions;
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
        //[Authorize()]
        //[Authorize(Roles = "Company.List,asdas,asdasda,")]
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
        [Route("GetById/{companyId:int}")]
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

        ///[HttpPost(template: "update")]
        [HttpPut(template: "update")]
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
        [Route("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            //var result = _companyService.Delete(company);
            //if (result.Success)
            //{
                return Ok();
            //}
            //else
            //    return BadRequest(result.Message);
        }
        [HttpPost(template: "Transaction")]
        public IActionResult TransactionTest(Company company)
        {
            var result = _companyService.TransactionalOperation(company);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
    }
}
