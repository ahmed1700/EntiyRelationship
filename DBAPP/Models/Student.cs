using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBAPP.Models
{
    class Student
    {
        public Student()
        {
            this.StudentCourse = new HashSet<StudentCourse>();
        }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        // Navigation Properites
        public virtual StudentAddress Address { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
    class StudentAddress
    {
        [Key]
        [ForeignKey("Student")]
        public int StudentAdressID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Student Student { get; set; }

    }
    class Course
    {
        public Course()
        {
            this.StudentCourse = new HashSet<StudentCourse>();
        }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }

    class StudentCourse
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

    }

}
