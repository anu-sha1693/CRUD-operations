using CRUD_operations.Models;
using CRUD_operations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CRUD_operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentService StudentService;
        public StudentController(IStudentService studentService)
        {
            this.StudentService = studentService;
        }
        [HttpGet]
        public List<Student> GetAll()
        {
            return StudentService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetbyId(int id)
        {
            var student = StudentService.GetbyId(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public ActionResult<Student> Add(Student student)
        {
            StudentService.Add(student);
            return CreatedAtAction(nameof(GetbyId), new { Id = student.Id }, student);
        }
        [HttpPut("{id}")]
        public ActionResult<Student> Update(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            try
            {
                StudentService.Update(student);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("NotFound"))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Student> Delete(int id)
        {
            try
            {
                StudentService.Delete(id);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Not Found"))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult<Student> PartialUpdate(int id, string name, double? gpa, bool? isenrolled, DateTime? dateofbirth, Gender? gender, List<String> courses)
        {
            try
            {
                StudentService.PartialUpdate(id, name, gpa, isenrolled, dateofbirth, gender, courses);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Not Found"))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }
    }
}