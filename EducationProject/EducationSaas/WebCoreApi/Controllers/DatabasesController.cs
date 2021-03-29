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
    public class DatabasesController : ControllerBase
    {
        private IDatabasesService _databaseService;

        public DatabasesController(IDatabasesService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _databaseService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }

        [HttpGet(template: "getById")]
        public IActionResult GetById(int databaseId)
        {
            var result = _databaseService.GetById(databaseId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }


        [HttpPost(template: "add")]
        public IActionResult Add(Database database)
        {
            var result = _databaseService.Add(database);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Database database)
        {
            var result = _databaseService.Update(database);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(Database database)
        {
            var result = _databaseService.Delete(database);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }

        
    }
}
