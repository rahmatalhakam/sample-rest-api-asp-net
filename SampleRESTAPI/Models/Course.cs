using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleRESTAPI.Models
{
    //[Table("Course")]
    public class Course
    {
        //[Column("Course_id")]
        public int CourseID { get; set; }

        //[Column("Judul")]
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        //[NotMapped]
        //[Column(TypeName = "decimal(5,2)")]
        [Required]
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
