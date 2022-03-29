using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;

namespace University.Test
{
    internal class Program
    {
        private static readonly UniversityModel university = new UniversityModel();
        private static readonly ICourseRepository courseRepository
            = new CourseRepository(new UniversityModel());
        static void Main(string[] args)
        {
            var courses = university.Course.ToList();
            var courses2 = courseRepository.GetAll().Result;
            foreach (var item in courses2)
            {
                Console.WriteLine($"{item.Title} {item.Credits}");
            }

            Console.ReadKey();
        }
    }
}
