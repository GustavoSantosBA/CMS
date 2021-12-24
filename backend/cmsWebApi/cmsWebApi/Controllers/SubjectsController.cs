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
    public class SubjectsController : ControllerBase
    {
        protected readonly SubjectsRepository _subjectsRepository;
        public SubjectsController(SubjectsRepository subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _subjectsRepository.Remove(id);
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
            return Ok(_subjectsRepository.List());
        }

        [HttpPost]
        public IActionResult Post(Subjects obj)
        {
            try
            {
                return Ok(_subjectsRepository.AddGet(obj));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
