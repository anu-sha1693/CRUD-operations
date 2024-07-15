using Microsoft.VisualBasic;

namespace CRUD_operations.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime Dateofbirth {  get; set; }
        public bool IsEnrolled { get; set; }
        public double Gpa {  get; set; }
        public List<String> Courses { get; set; }
    }
}
