using DBAPP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAPP.Data
{
    class SchoolDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SchoolDB;Data Source=.");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAdress { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
               .HasKey(sc => new { sc.StudentID, sc.CourseID });
            modelBuilder.Entity<StudentCourse>()
          .HasOne(pt => pt.Course)
          .WithMany(p => p.StudentCourse)
          .HasForeignKey(pt => pt.CourseID);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(pt => pt.Student)
                .WithMany(t => t.StudentCourse)
                .HasForeignKey(pt => pt.StudentID);
        }
    }
}
