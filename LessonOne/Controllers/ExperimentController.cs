using Dapper;
using LessonOne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Reflection.Metadata.Ecma335;

namespace LessonOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExperimentController : ControllerBase
    {
        string connectionString = "Host=localhost;Port=5432;Database=APIprojectOneDB;User Id=postgres;Password=Maqsudkhan";

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            IEnumerable<Person>? experiments = connection.Query<Person>("select * from persons;");
            connection.Close();
            return experiments;
        }

        [HttpPost]
        public PersonDTO PostWithDapper(PersonDTO model)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var count = connection.Execute($"insert into persons(name, surname, age) values(@name,@surname,@age);",new {name= model.Name,surname=model.Surname ,age= model.Age });
            connection.Close();
            return model;
        }

        [HttpDelete]
        public string Delete(int id)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var count = connection.Execute($"delete from persons where Id=@id;", new { id=id });
            connection.Close();
            return $"{id} id o'chirildi";
        }



        [HttpPut]
        public string Put(int id, PersonDTO personModel)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var count = connection.Execute($"update persons set name=@Name,surname=@Surname,age=@age where Id=@id;", new { Name = personModel.Name,Surname=personModel.Surname,age=personModel.Age, id = id });
            connection.Close();
            return $"{id} idli user o'zgardi";
        }


      

        [HttpPatch]
        public string Patch(int id,string changeName)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var count = connection.Execute($"update persons set name=@newName  where Id=@id;", new { newName=changeName,id = id });
            connection.Close();
            return $"{id} idli username o'zgardi.";
        }

       

    }
}
