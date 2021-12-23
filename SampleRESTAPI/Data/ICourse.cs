using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleRESTAPI.Models;

namespace SampleRESTAPI.Data
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByTitle(string title);
        Task<IEnumerable<Course>> GetByStudentID(int id);
    }
}
