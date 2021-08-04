using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Data;
using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("get-students")]
        public IActionResult GetStudents()
        {
            var students = _applicationDbContext.Students.ToList();
            var response = new ResponseModel<List<Student>>();
            response.Success = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "successful";
            response.Data = students;
            return Ok(response);
        }

        [HttpPost("create-student")]
        public IActionResult CreateStudent([FromBody] Student model)
        {
            
            var response = new ResponseModel<Student>();
            
            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Required fields are not completed";
                return BadRequest(response);
            }
            response.Success = true;
            response.StatusCode = HttpStatusCode.OK;

            _applicationDbContext.Students.Add(model);
            _applicationDbContext.SaveChanges();
            response.Data = model;
            return Ok(response);
        }
    }
}
