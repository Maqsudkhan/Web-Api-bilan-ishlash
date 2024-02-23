using StudyCenterProject.Entities;
using StudyCenterProject.Models;
using StudyCenterProject.MyPattern.IRepositories;
using StudyCenterProject.MyPattern.Repositories;
using StudyCenterProject.MyServices.IServices;

namespace StudyCenterProject.MyServices.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly StudentRepository _studentRepository;
        public StudentServices(StudentRepository studentServices)
        {
            _studentRepository = studentServices;
        }


        public string CreateStudent(StudentDTO studentDTO)
        {
            if (studentDTO.full_name == null || studentDTO.full_name == "")
            {
                return "Service error name is null❗";
            }
            try
            {
                return _studentRepository.CreateStudent(studentDTO);
            }
            catch (Exception ex)
            {
                return "Erron in service❗";
            }
        }

        public string DeleteStudent(int id)
        {
            if (id < 0)
            {
                return "Id should be greater than 0❗";
            }
            try
            {
                return _studentRepository.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                return "Error in service❗";
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return _studentRepository.GetAllStudents();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Student>();
            }
        }

        public IEnumerable<Student> GetStudentById(int id)
        {
            if (id < 0)
            {
                 return Enumerable.Empty<Student>();
            }
            try
            {
                return _studentRepository.GetStudentById(id);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Student>();
            }
        }

        public int UpdatePatchStudent(int id, string Name)
        {
            throw new NotImplementedException();
            // O'xshamayaptikuuuuuu
        }

        public StudentDTO UpdatePutStudent(int id, StudentDTO studentDTO)
        {
            try
            {
                return _studentRepository.UpdatePutStudent(id, studentDTO);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                // Bunisi ham
            }
        }
    }
}
