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
    public class WareHouseController : ControllerBase
    {
        private readonly ICompanyWareHouseService _wareHouseService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHouseService"></param>
        public WareHouseController(ICompanyWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        /// <summary>
        /// Get All WareHouses..
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _wareHouseService.GetWareHouseList();
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
        /// <param name="wareHouseId"></param>
        /// <returns>DataResult WareHouseDto</returns>
        [HttpGet(template: "getById/{wareHouseId:int}")]
        // [Route("GetById/{wareHouseId:int}")]
        public IActionResult GetById(int wareHouseId)
        {
            var result = _wareHouseService.GetWareHouseById(wareHouseId);
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
        public IActionResult Add(CompanyWareHouse wareHouse)
        {
            var result = _wareHouseService.Add(wareHouse);
            var cacheUpdate = GetList();
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
        //[HttpPost(template: "update")]
        [HttpPut(template: "update")]
        public IActionResult Update(CompanyWareHouse wareHouse)
        {
            var result = _wareHouseService.Update(wareHouse);
            var cacheUpdate = GetList();
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
        //  [Route("Delete")]
        public IActionResult Delete(CompanyWareHouse wareHouse)
        {
            wareHouse.Deleted = true;
            var result = _wareHouseService.Update((wareHouse));
            var cacheUpdate = GetList();
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }



    }
}
