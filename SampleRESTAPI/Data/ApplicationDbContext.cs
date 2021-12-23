using System;
using Microsoft.EntityFrameworkCore;
using SampleRESTAPI.Models;

namespace SampleRESTAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        //fluent aip
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Student>().ToTable("Mahasiswa");
        //}
    }
}
