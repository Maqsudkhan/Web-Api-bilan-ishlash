using StudyCenterProject.Entities;
using StudyCenterProject.Models;

namespace StudyCenterProject.MyPattern
{
    public interface IStudentRepository
    {
        public string CreateStudent(StudentDTO studentDTO);
        public IEnumerable<Student> GetAllStudents();
        public Student GetStudentById(int id);
        public string DeleteStudent(int  id);
        public Student UpdateStudent(int id,  StudentDTO studentDTO);
    }
}
