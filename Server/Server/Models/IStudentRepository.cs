using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> AddStudent(Student p);
        Task<Student> UpdateStudent(int id, Student p);
        Task<Student> DeleteStudent(int id);
    }
}
