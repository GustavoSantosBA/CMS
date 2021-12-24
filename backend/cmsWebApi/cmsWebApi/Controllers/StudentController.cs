using cmsWebApi.models.Data.repository;
using cmsWebApi.models.Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        protected readonly StudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentRepository.Remove(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentRepository.List());
        }

        [HttpPost]
        public IActionResult Post(Student obj)
        {
            try
            {
                return Ok(_studentRepository.AddGet(obj));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
