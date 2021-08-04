using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<string> products = new List<string> { "Laptop", "Phone", "Battery", "Car" };


        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            return Ok(products);

        }
        [HttpGet]
        [Route("get-product/{name}")]
        public IActionResult GetProduct(string name)
        {
            if (products.Contains(name))
            {

                return Ok(name);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("create-product/{name}")]
        public IActionResult CreateProduct(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Please provide product name");
            }
            if (products.Contains(name))
            {

                return BadRequest("product already exist");
            }
            products.Add(name);
            return Ok("product created successfully.");
        }


        [HttpGet]
        [Route("get-product-by-index/{index:int}")]
        public IActionResult GetProductByIndex(int index)
        {
            
            if (index < 0 || index >= products.Count)
            {

                return BadRequest("product provided is invalid");
            }
            
            return Ok(products[index]);
        }
    }
}
