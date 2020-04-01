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
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get All Customer Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new { code = "0000", msg = "", obj = _customerService.GetAll() });
        }

        /// <summary>
        /// Get One Customer Data by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public IActionResult GetOneByName(string name)
        {
            return Ok(new { code = "0000", msg = "", obj = _customerService.GetOneByName(name) });
        }

        /// <summary>
        /// Get One Customer Data by ObjectId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetOneById(string id)
        {
            return Ok(new { code = "0000", msg = "", obj = _customerService.GetOneById(id) });
        }

        /// <summary>
        /// Post One Customer Data
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            try
            {
                _customerService.InsertOne(customer);
                return Ok(new { code = "0000", msg = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = ex.GetHashCode().ToString(), msg = ex.ToString() });
            }
        }

        /// <summary>
        /// Put One Customer Data
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            try
            {
                _customerService.UpdateOne(customer);
                return Ok(new { code = "0000", msg = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = ex.GetHashCode().ToString(), msg = ex.ToString() });
            }
        }

    }
}
