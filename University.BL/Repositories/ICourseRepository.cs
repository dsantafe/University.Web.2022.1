using System.Collections.Generic;
using University.BL.DTOs;
using University.BL.Models;

namespace University.BL.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        IEnumerable<Course> GetCoursesByInstructorId(int instructorID);
        IEnumerable<DonutExampleDTO> GetReport();
    }
}
