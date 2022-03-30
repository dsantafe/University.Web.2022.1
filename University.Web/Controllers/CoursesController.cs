using System.Threading.Tasks;
using System.Web.Mvc;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;
using AutoMapper;
using System.Linq;
using University.BL.DTOs;

namespace University.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IMapper mapper = MvcApplication.MapperConfiguration.CreateMapper();
        private readonly ICourseRepository courseRepository = new CourseRepository(new UniversityModel());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> IndexJson()
        {
            var coursesModel = await courseRepository.GetAll();
            var coursesDTO = coursesModel.Select(x => mapper.Map<CourseDTO>(x));

            return Json(coursesDTO, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView(new CourseDTO());
        }
    }
}