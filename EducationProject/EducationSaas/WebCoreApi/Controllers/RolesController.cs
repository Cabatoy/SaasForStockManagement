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
    public class RolesController : ControllerBase
    {
        private IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _rolesService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }

        [HttpGet(template: "getById")]
        public IActionResult GetById(int roleId)
        {
            var result = _rolesService.GetById(roleId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }


        [HttpPost(template: "add")]
        public IActionResult Add(Roles role)
        {
            var result = _rolesService.Add(role);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Roles role)
        {
            var result = _rolesService.Update(role);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(Roles role)
        {
            var result = _rolesService.Delete(role);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
    }
}
