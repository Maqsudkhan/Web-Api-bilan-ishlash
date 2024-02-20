using Dapper;
using Npgsql;
using StudyCenterProject.Entities;
using StudyCenterProject.Models;

namespace StudyCenterProject.MyPattern
{
    public class StudentRepository : IStudentRepository

    {
        public IConfiguration _configuration;
        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "INSERT INTO students (full_name, age, course_id, phone_number, parents_phone_number, shot_number) VALUES (@full_name, @age, @course_id, @phone_number, @parents_phone_number, @shot_number)";
                    var parameters = new StudentDTO
                    {
                        full_name = studentDTO.full_name,
                        age = studentDTO.age,
                        course_id = studentDTO.course_id,
                        phone_number = studentDTO.phone_number,
                        parents_phone_number = studentDTO.parents_phone_number,
                        shot_number = studentDTO.shot_number
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

        public IEnumerable<Student> GetAllStudents()
        {

            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "select * from students";
                var x = connection.Query<Student>(query);
              
                return x;
            }

        }

        public string DeleteStudent(int id)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = connection.Execute("delete from students where student_id=@id", new { id = id });
                return "O'chirildi";
            }
        }

        public Student GetStudentById(int id)
        {
            using(var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = connection.Query<Student>("select * from students where sutdent_id = @id", new { id = id });
                return (Student)query;
            }
            

        }

        public Student UpdateStudent(int id, StudentDTO studentDTO)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = connection.Query<Student>("update students set @full_name, @age, @course_id, @phone_number, @parents_phone_number, @shot_number where student_id = @id", 
                    new {full_name = studentDTO,age = studentDTO, couse_id = studentDTO, phone_number = studentDTO, parents_phone_number = studentDTO, shot_number = studentDTO,id = id });
                return (Student)query;
            }
        }

    }
}
