using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleRESTAPI.Models
{
    public class Student
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] biar tidak increment
        [Key] //untuk primary key
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
