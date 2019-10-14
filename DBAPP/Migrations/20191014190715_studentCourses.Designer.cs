﻿// <auto-generated />
using DBAPP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBAPP.Migrations
{
    [DbContext(typeof(SchoolDBContext))]
    [Migration("20191014190715_studentCourses")]
    partial class studentCourses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBAPP.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DBAPP.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudentName");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DBAPP.Models.StudentAddress", b =>
                {
                    b.Property<int>("StudentAdressID");

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.HasKey("StudentAdressID");

                    b.ToTable("StudentAdress");
                });

            modelBuilder.Entity("DBAPP.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentID");

                    b.Property<int>("CourseID");

                    b.HasKey("StudentID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("DBAPP.Models.StudentAddress", b =>
                {
                    b.HasOne("DBAPP.Models.Student", "Student")
                        .WithOne("Address")
                        .HasForeignKey("DBAPP.Models.StudentAddress", "StudentAdressID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DBAPP.Models.StudentCourse", b =>
                {
                    b.HasOne("DBAPP.Models.Course", "Course")
                        .WithMany("StudentCourse")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DBAPP.Models.Student", "Student")
                        .WithMany("StudentCourse")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
