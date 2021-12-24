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
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        protected readonly TeacherRepository _teacherRepository;
        public TeacherController(TeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _teacherRepository.Remove(id);
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
            return Ok(_teacherRepository.List());
        }

        [HttpPost]
        public IActionResult Post(Teacher obj)
        {
            try
            {
                return Ok(_teacherRepository.AddGet(obj));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
