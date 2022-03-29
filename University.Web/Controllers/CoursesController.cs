using System.Threading.Tasks;
using System.Web.Mvc;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;

namespace University.Web.Controllers
{
    public class CoursesController : Controller
    {
        private static readonly ICourseRepository courseRepository 
            = new CourseRepository(new UniversityModel());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> IndexJson()
        {
            var courses = await courseRepository.GetAll();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}