using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicencesController : ControllerBase
    {
        private ILicenceService _licenceService;
        public LicencesController(ILicenceService licenceService)
        {
            _licenceService = licenceService;
        }

        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _licenceService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }

        [HttpGet(template: "getById")]
        public IActionResult GetById(int licenceId)
        {
            var result = _licenceService.GetById(licenceId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }


        [HttpPost(template: "add")]
        public IActionResult Add(Licence licence)
        {
            var result = _licenceService.Add(licence);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Licence licence)
        {
            var result = _licenceService.Update(licence);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(Licence licence)
        {
            var result = _licenceService.Delete(licence);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
    }
}
