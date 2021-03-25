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
    public class LocalsController : ControllerBase
    {
        private ILocalsService _localsService;
        public LocalsController(ILocalsService localsService)
        {
            _localsService = localsService;
        }

        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _localsService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }

        [HttpGet(template: "getById")]
        public IActionResult GetById(int localsId)
        {
            var result = _localsService.GetById(localsId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }


        [HttpPost(template: "add")]
        public IActionResult Add(Locals locals)
        {
            var result = _localsService.Add(locals);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Locals locals)
        {
            var result = _localsService.Update(locals);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(Locals locals)
        {
            var result = _localsService.Delete(locals);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
    }
}
