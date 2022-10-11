using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class StudentRepository:IStudentRepository
    {
        private readonly Context context;

        public StudentRepository(Context context)
        {
            this.context = context;
        }
        public async Task<Student> AddStudent(Student p)
        {
            var res = await context.kar_students.AddAsync(p);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var obj = await context.kar_students.FindAsync(id);
            context.Remove(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Student> GetStudent(int id)
        {
            return await context.kar_students.FindAsync(id);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await context.kar_students.ToListAsync();
        }

        public async Task<Student> UpdateStudent(int id, Student p)
        {
            var obj = await context.kar_students.FindAsync(id);
            obj.Name = p.Name;
            obj.Marks = p.Marks;
            await context.SaveChangesAsync();
            return p;
        }
    }
}
