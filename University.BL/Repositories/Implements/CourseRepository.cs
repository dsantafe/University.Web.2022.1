using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.BL.DTOs;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly UniversityModel universityModel;
        public CourseRepository(UniversityModel universityModel) : base(universityModel)
        {
            this.universityModel = universityModel;
        }

        public IEnumerable<Course> GetCoursesByInstructorId(int instructorID)
        {
            var courses = universityModel.CourseInstructor
                .Where(x => x.InstructorID == instructorID)
                .Select(x => x.Course);
            return courses;
        }

        public IEnumerable<DonutExampleDTO> GetReport()
        {
            var result = from _course in universityModel.Course
                         join _enroll in universityModel.Enrollment on _course.CourseID equals _enroll.CourseID
                         group _course by _course.Title into query
                         select query;

            var report = result.Select(x => new DonutExampleDTO
            {
                Label = x.Key,
                Value = x.Count()
            });

            return report;
        }

        public async new Task Delete(int id)
        {
            var enrollments = universityModel.Enrollment.Where(x => x.CourseID == id);
            var courseInstructors = universityModel.CourseInstructor.Where(x => x.CourseID == id);

            if (!enrollments.Any() && !courseInstructors.Any())
            {
                var course = await GetById(id);
                universityModel.Course.Remove(course);
                await universityModel.SaveChangesAsync();
            }
            else
                throw new Exception("El curso tiene dependencias.");

            //universityModel.Enrollment.RemoveRange(enrollments);
            //universityModel.CourseInstructor.RemoveRange(courseInstructors);
            //await universityModel.SaveChangesAsync();
        }
    }
}
