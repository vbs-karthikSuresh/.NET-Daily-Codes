using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Student> kar_students { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                ID = 1,
                Name = "Karthik",
                Marks = 30
            }
                );
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                ID = 2,
                Name = "Suresh",
                Marks = 50
            });
        }
    }
}
