using Dapper;
using Npgsql;
using StudyCenterProject.Entities;
using StudyCenterProject.Models;
using StudyCenterProject.MyPattern.IRepositories;

namespace StudyCenterProject.MyPattern.Repositories
{
    public class StudentRepository : IStudentRepository

    {
        private readonly IConfiguration _configuration;
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
                var query = connection.Execute("delete from students where student_id=@id", new { id });
                return "O'chirildi";
            }
        }

        public IEnumerable<Student> GetStudentById(int id)
        {
            string query = "select * from students where student_id = @id";

            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                //connection.Execute(query, new Student { id = id });
                var x = connection.Query<Student>(query, new { id });
                return x;
            }


        }

        public StudentDTO UpdatePutStudent(int id, StudentDTO studentDTO)
        {
            string query = "update students set full_name = @full_name, age = @age, course_id = @course_id, " +
            "phone_number = @phone_number, parents_phone_number = @parents_phone_number, " +
            $"shot_number = @shot_number where student_id = {id}";
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Execute(query, new StudentDTO
                {
                    full_name = studentDTO.full_name,
                    age = studentDTO.age,
                    course_id = studentDTO.course_id,
                    phone_number = studentDTO.phone_number,
                    parents_phone_number = studentDTO.parents_phone_number,
                    shot_number = studentDTO.shot_number
                });

                return studentDTO;
            }
        }

        public int UpdatePatchStudent(int id, string name)
        {
            string query = "update students set full_name = @name where student_id = @id";
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var x = connection.Execute(query, new { Name = name, Id = id });
                return x;
            }
        }
    }
}
