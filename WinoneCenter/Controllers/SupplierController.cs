using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinoneCenter.Services;
using WinoneCenter.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WinoneCenter.Controllers
{
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        private readonly SupplierService _supplierService;

        public SupplierController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        /// <summary>
        /// Get All Supplier Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new { code = "0000", msg = "", obj = _supplierService.GetAll() });
        }

        /// <summary>
        /// Get One Supplier Data by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public IActionResult GetOneByName(string name)
        {
            return Ok(new { code = "0000", msg = "", obj = _supplierService.GetOneByName(name) });
        }

        /// <summary>
        /// Get One Supplier Data by ObjectId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetOneById(string id)
        {
            return Ok(new { code = "0000", msg = "", obj = _supplierService.GetOneById(id) });
        }

        /// <summary>
        /// Post One Supplier Data
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Supplier supplier)
        {
            try
            {
                _supplierService.InsertOne(supplier);
                return Ok(new { code = "0000", msg = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = ex.GetHashCode().ToString(), msg = ex.ToString() });
            }
        }

        /// <summary>
        /// Put One Supplier Data
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Supplier supplier)
        {
            try
            {
                _supplierService.UpdateOne(supplier);
                return Ok(new { code = "0000", msg = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = ex.GetHashCode().ToString(), msg = ex.ToString() });
            }
        }

    }
}
