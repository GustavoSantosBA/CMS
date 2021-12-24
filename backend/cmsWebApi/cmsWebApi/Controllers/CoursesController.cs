using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsWebApi.models.Data.repository;
using cmsWebApi.models.Domain.entities;
using Microsoft.AspNetCore.Mvc;

namespace cmsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        protected readonly CourseRepository _coursesRepository;
        public CoursesController(CourseRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _coursesRepository.Remove(id);
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
            return Ok(_coursesRepository.List());
        }

        [HttpPost]
        public IActionResult Post(Courses obj)
        {
            try
            {
                return Ok(_coursesRepository.AddGet(obj));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}