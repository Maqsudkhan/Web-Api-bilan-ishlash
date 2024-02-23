using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using StudyCenterProject.Entities;
using StudyCenterProject.Models;
using StudyCenterProject.MyPattern.IRepositories;

namespace StudyCenterProject.MyPattern.Repositories
{
    public class TeacherRepositories : ITeacherRepositories
    {
        private readonly IConfiguration _configuration;
        public TeacherRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateTeacher(TeacherDTO teacherDTO)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "INSERT INTO teachers (full_name, age, salary, phone_number, groups_count, experience) " +
                        "VALUES (@full_name, @age, @salary, @phone_number, @groups_count, @experience)";
                    var parameters = new TeacherDTO
                    {
                        full_name = teacherDTO.full_name,
                        age = teacherDTO.age,
                        salary = teacherDTO.salary,
                        phone_number = teacherDTO.phone_number,
                        groups_count = teacherDTO.groups_count,
                        experience = teacherDTO.experience
                    };
                    connection.Execute(query, parameters);

                }
                return "Malumot muvofaqqiyatli yaratildi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IEnumerable<Teacher> GetAllTeachers()
        {

            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "Select * from teachers";
                var result =  connection.Query<Teacher>(query);
                return result;
            }
        }

        public string DeleteTeacher(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Teacher> GetTeacherById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdatePatchTeacher(int id, string Name)
        {
            throw new NotImplementedException();
        }

        public TeacherDTO UpdatePutTeacher(int id, TeacherDTO teacherDTO)
        {
            throw new NotImplementedException();
        }
    }
}
