using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleRESTAPI.Models;

namespace SampleRESTAPI.Data
{
    public interface IStudent : ICrud<Student>
    {
        // semua student yang mengambil course tertentu
        Task<IEnumerable<Student>> GetByCourseID(int id);
    }
}
