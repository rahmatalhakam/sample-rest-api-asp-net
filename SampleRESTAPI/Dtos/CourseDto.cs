using System;
namespace SampleRESTAPI.Dtos
{
    public class CourseDto
    {
        public int CourseID { get; set; }

        public string Title { get; set; }

        // 1 credit = 1.5 hours
        public float TotalHours { get; set; }
    }
}
