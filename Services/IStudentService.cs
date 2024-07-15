using CRUD_operations.Models;
using Microsoft.VisualBasic;

namespace CRUD_operations.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetbyId(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
        void PartialUpdate(int id,string name,double? gpa,bool? isenrolled,DateTime? dateofbirth,Gender? gender,List<String> Courses);
    }
}
