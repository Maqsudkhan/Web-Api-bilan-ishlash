using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyCenterProject.Entities;
using StudyCenterProject.MyPattern.IRepositories;

namespace StudyCenterProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepositories _techerRepository;
        public TeachersController(ITeacherRepositories techerRepository)
        {
            _techerRepository = techerRepository;
        }

        [HttpPost]
        public IActionResult CreateTeacher(TeacherDTO teacherDTO)
        {
            try
            {
                var result = _techerRepository.CreateTeacher(teacherDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            try
            {
                var result = _techerRepository.GetAllTeachers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
