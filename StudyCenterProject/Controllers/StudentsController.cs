using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyCenterProject.Entities;
using StudyCenterProject.MyPattern;

namespace StudyCenterProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentDTO model)
        {
            try
            {
                var response = _studentRepository.CreateStudent(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var response = _studentRepository.GetAllStudents();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var response = _studentRepository.GetStudentById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var response = _studentRepository.DeleteStudent(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdatePutStudents(int id, StudentDTO studentDTO)
        {
            try
            {
                var respose = _studentRepository.UpdateStudent(id, studentDTO);
                return Ok(respose);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
