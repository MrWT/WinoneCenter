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
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get All Product Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new { code = "0000", msg = "", obj = _productService.GetAll() });
        }

        /// <summary>
        /// Get One Product Data by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public IActionResult GetOneByName(string name)
        {
            return Ok(new { code = "0000", msg = "", obj = _productService.GetOneByName(name) });
        }

        /// <summary>
        /// Get One Product Data by ObjectId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetOneById(string id)
        {
            return Ok(new { code = "0000", msg = "", obj = _productService.GetOneById(id) });
        }

        /// <summary>
        /// Post One Product Data
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                _productService.InsertOne(product);
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
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productService.UpdateOne(product);
                return Ok(new { code = "0000", msg = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = ex.GetHashCode().ToString(), msg = ex.ToString() });
            }
        }

    }
}
