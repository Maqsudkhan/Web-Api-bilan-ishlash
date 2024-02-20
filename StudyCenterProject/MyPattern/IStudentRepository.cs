using StudyCenterProject.Entities;
using StudyCenterProject.Models;

namespace StudyCenterProject.MyPattern
{
    public interface IStudentRepository
    {
        public string CreateStudent(StudentDTO studentDTO);
        public IEnumerable<Student> GetAllStudents();
        public IEnumerable<Student> GetStudentById(int id);
        public string DeleteStudent(int  id);
        public StudentDTO UpdatePutStudent(int id,  StudentDTO studentDTO);
        public int UpdatePatchStudent(int id, string Name);
    }
}
