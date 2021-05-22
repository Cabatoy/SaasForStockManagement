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
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyLocalsController : ControllerBase
    {
         ICompanyLocalService _companyLocalService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyLocalService"></param>
         public CompanyLocalsController(ICompanyLocalService companyLocalService)
         {
             _companyLocalService = companyLocalService;
         }


         /// <summary>
        /// Get All WareHouses..
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "getall")]
        public IActionResult GetLocalList()
        {
            var result = _companyLocalService.GetLocalList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }

        /// <summary>
        /// getById
        /// </summary>
        /// <returns>DataResult companyLocal</returns>
        [HttpGet(template: "getById/{companyLocalId:int}")]
        public IActionResult GetById(int localId)
        {
            var result = _companyLocalService.GetLocalByID(localId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        /// <summary>
        /// WareHouse Add
        /// </summary>
        /// <returns>DataResult</returns>
        [HttpPost(template: "add")]
        public IActionResult Add(CompanyLocal companyLocal)
        {
            var result = _companyLocalService.Add(companyLocal);
            var cacheUpdate = GetLocalList();
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }


        /// <summary>
        /// update
        /// </summary>
        /// <returns>DataResult</returns>
        [HttpPut(template: "update")]
        public IActionResult Update(CompanyLocal companyLocal)
        {
            var result = _companyLocalService.Update(companyLocal);
            var cacheUpdate = GetLocalList();
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }

        /// <summary>
        /// Silme işlemi ilgili kolona 
        /// update şeklinde olur.
        /// </summary>
        /// <returns></returns>
        [HttpPost(template: "delete")]
        public IActionResult Delete(CompanyLocal companyLocal)
        {
            companyLocal.Deleted = true;
            var result = _companyLocalService.Update((companyLocal));
            var cacheUpdate = GetLocalList();
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
    }
}
