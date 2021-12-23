using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Dtos;
using SampleRESTAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudent _student;
        private IMapper _mapper;
        public StudentsController(IStudent student, IMapper mapper)
        {
            _student = student ?? throw new ArgumentNullException(nameof(mapper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> Get()
        {
            var students = await _student.GetAll();
            //List<StudentDto> listStudentDto = new List<StudentDto>();
            //foreach (var student in students)
            //{
            //    var studendto = new StudentDto {
            //        ID= student.ID,
            //        Name = $"{student.FirstName} {student.LastName}",
            //        EnrollmentDate = student.EnrollmentDate
            //    };
            //    listStudentDto.Add(studendto);
            //}
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> Get(string id)
        {
            var results = await _student.GetById(id);
            if (results == null)
                return NotFound();
            return Ok(_mapper.Map<StudentDto>(results));

        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post([FromBody] StudentForCreateDto student)
        {
            try
            {
                var dtos = _mapper.Map<Student>(student);
                var result = await _student.Insert(dtos);
                return Ok(_mapper.Map<StudentDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> Put(int id, [FromBody] StudentForCreateDto student)
        {
            try
            {
                var result = await _student.Update(id.ToString(), _mapper.Map<Student>(student));
                return Ok(_mapper.Map<StudentDto>(result));
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
                await _student.Delete(id.ToString());
                return Ok($"Data student {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("{id}")]
        //public ActionResult Get(int id)
        //{
        //    //var result = students.Where(s => s.ID == id).SingleOrDefault();
        //    var result = (from s in students where s.ID==id select s).SingleOrDefault();
        //    if (result != null)
        //        return Ok(result);
        //    else
        //        return NotFound();
        //}

        //[HttpGet("byname")]
        //public ActionResult Get(string firstName="", string lastname="")
        //{
        //    var results = students.Where(s => s.FirstName.ToLower().StartsWith(firstName.ToLower()) && s.LastName.ToLower().StartsWith(lastname.ToLower())).ToList();
        //    //var results = (from s in students where s.FirstName.ToLower().Contains(firstName.ToLower()) select s).ToList();
        //    if (results != null)
        //        return Ok(results);
        //    else
        //        return NotFound();
        //}

        [HttpGet("bycourseid")]
        public async Task<IEnumerable<Student>> GetByCourseId(int id)
        {
            var results = await _student.GetByCourseID(id);
            return results;
        }
    }
}
