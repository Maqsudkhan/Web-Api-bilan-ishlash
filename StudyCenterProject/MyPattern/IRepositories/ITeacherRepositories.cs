using Microsoft.AspNetCore.Mvc;
using StudyCenterProject.Entities;
using StudyCenterProject.Models;

namespace StudyCenterProject.MyPattern.IRepositories
{
    public interface ITeacherRepositories
    {
        public string CreateTeacher(TeacherDTO teacherDTO);
        public IEnumerable<Teacher> GetAllTeachers();
        public IEnumerable<Teacher> GetTeacherById(int id);
        public string DeleteTeacher(int id);
        public TeacherDTO UpdatePutTeacher(int id, TeacherDTO teacherDTO);
        public int UpdatePatchTeacher(int id, string Name);
    }
}
