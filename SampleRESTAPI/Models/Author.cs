using System;
namespace SampleRESTAPI.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MainCategory { get; set; }

    }
}
