using System;
using System.Linq;
using SampleRESTAPI.Models;

namespace SampleRESTAPI.Data
{
    public static class DbInitilizer
    {
        public static void Initilize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }
            var students = new Student[]
            {
                new Student{FirstName="Rahmat", LastName="Al Hakam", EnrollmentDate=System.DateTime.Parse("2021-12-12")},
                new Student{FirstName="Mamat", LastName="Rebel", EnrollmentDate=System.DateTime.Parse("2021-10-12")},
                new Student{FirstName="Dadang", LastName="Rokes", EnrollmentDate=System.DateTime.Parse("2021-12-10")},
                new Student{FirstName="Imam", LastName="Masakan Padang", EnrollmentDate=System.DateTime.Parse("2020-12-12")},
                new Student{FirstName="Test", LastName="Doang", EnrollmentDate=System.DateTime.Now},
            };
            foreach (var student in students)
            {
                context.Students.Add(student);
            }

            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Title="Cloud Fundamentals", Credits=3},
                new Course{Title="Microservices Architecture", Credits=3},
                new Course{Title="Frontend Programming", Credits=3},
                new Course{Title="Backend RESTful API", Credits=3},
                new Course{Title="Entity framework core", Credits=3},
            };

            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }

            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1, CourseID=1, Grade=Grade.A},
                new Enrollment{StudentID=1, CourseID=2, Grade=Grade.B},
                new Enrollment{StudentID=1, CourseID=3, Grade=Grade.C},
                new Enrollment{StudentID=2, CourseID=1, Grade=Grade.C},
                new Enrollment{StudentID=2, CourseID=2, Grade=Grade.C},
                new Enrollment{StudentID=2, CourseID=3, Grade=Grade.C},
                new Enrollment{StudentID=3, CourseID=1, Grade=Grade.A},
                new Enrollment{StudentID=3, CourseID=2, Grade=Grade.B},
                new Enrollment{StudentID=3, CourseID=3, Grade=Grade.C},
            };

            foreach (var enrollment in enrollments)
            {
                context.Enrollments.Add(enrollment);
            }

            context.SaveChanges();
        }

    }
}
