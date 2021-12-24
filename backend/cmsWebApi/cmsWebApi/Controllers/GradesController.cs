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

    public class GradesController : ControllerBase
    {
        protected readonly GradesRepository _gradesRepository ;
        public GradesController(GradesRepository gradesRepository)
        {
            _gradesRepository = gradesRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _gradesRepository.Remove(id);
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
            return Ok(_gradesRepository.List());
        }

        [HttpPost]
        public IActionResult Post(Grades obj)
        {
            try
            {
                return Ok(_gradesRepository.AddGet(obj));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
