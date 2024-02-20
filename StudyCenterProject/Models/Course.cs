namespace StudyCenterProject.Models
{
    public class Course
    {
        public int course_id { get; set; }
        public string course_name { get; set; }
        public int teacher_id { get; set; }
        public decimal price { get; set; }
        public string descriptions { get; set; }
        public int students_count { get; set; }
    }
}
