using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Dtos;
using SampleRESTAPI.Models;

namespace SampleRESTAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;
        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course ?? throw new ArgumentNullException(nameof(mapper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var courses = await _course.GetAll();
            var dtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(string id)
        {
            var course = await _course.GetById(id);
            if (course == null)
                return NotFound();
            var dto = _mapper.Map<CourseDto>(course);
            return Ok(dto);
        }

        [HttpGet("bytitle")]
        public async Task<IEnumerable<Course>> GetByTitle(string title)
        {
            return await _course.GetByTitle(title);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post([FromBody]CourseForCreateDto course)
        {
            try
            {
                var result = await _course.Insert(_mapper.Map<Course>(course));
                var dto = _mapper.Map<CourseDto>(result);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody]CourseForCreateDto course)
        {
            try
            {
                var result = await _course.Update(id.ToString(), _mapper.Map<Course>(course));
                return Ok(_mapper.Map<CourseDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                 await _course.Delete(id.ToString());
                return Ok($"Data student {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bystudentid")]
        public async Task<IEnumerable<Course>> GetByStudentID(int id)
        {
            return await _course.GetByStudentID(id);
        }

    }
}
