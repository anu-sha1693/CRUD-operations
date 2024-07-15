using CRUD_operations.Models;
using System.Text.Json.Serialization;
using System.Xml;
using Microsoft.VisualBasic;

namespace CRUD_operations.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>();
        private static int NextId = 1;
       
        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetbyId(int id)
        {
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }
        public void Add(Student student)
        {
            student.Id = NextId++;
            students.Add(student);
          
        }
        public void Update(Student student)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == student.Id)
                {
                    students[i] = student;
                 
                    return;
                }
            }
            throw new Exception($"student with {student.Id} is not found.");
        }
        public void Delete(int id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students.RemoveAt(i);
                  
                    return;
                }
            }
            throw new Exception($"Student with {id} is not found");
        }
        public void PartialUpdate(int id, string name, double? gpa, bool? isenrolled, DateTime? dateofbirth, Gender? gender, List<String> courses)
        {
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    if (name != null) student.Name = name;
                    if (gpa.HasValue) student.Gpa = gpa.Value;
                    if (isenrolled.HasValue) student.IsEnrolled = isenrolled.Value;
                    if (dateofbirth.HasValue) student.Dateofbirth = dateofbirth.Value;
                    if (gender.HasValue) student.Gender = gender.Value;
                    if (courses != null) student.Courses = courses;
                 
                    return;
                }
            }
            throw new Exception($"student with {id} is not found");
        }
        
    }
}
