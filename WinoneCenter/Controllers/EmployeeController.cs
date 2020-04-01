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
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get All Employee Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new { code = "0000", msg = "", obj = _employeeService.GetAll() });
        }

        /// <summary>
        /// Get One Employee Data by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public IActionResult GetOneByName(string name)
        {
            return Ok(new { code = "0000", msg = "", obj = _employeeService.GetOneByName(name) });
        }

        /// <summary>
        /// Get One Employee Data by ObjectId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetOneById(string id)
        {
            return Ok(new { code = "0000", msg = "", obj = _employeeService.GetOneById(id) });
        }

        /// <summary>
        /// Post One Employee Data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                _employeeService.InsertOne(employee);
                return Ok(new { code = "0000", msg = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = ex.GetHashCode().ToString(), msg = ex.ToString() });
            }
        }

        /// <summary>
        /// Put One Employee Data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            try
            {
                _employeeService.UpdateOne(employee);
                return Ok(new { code = "0000", msg = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = ex.GetHashCode().ToString(), msg = ex.ToString() });
            }
        }

    }
}
