using System.Threading.Tasks;
using System.Web.Mvc;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;
using AutoMapper;
using System.Linq;
using University.BL.DTOs;
using System;

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

        [HttpPost]
        public async Task<ActionResult> Create(CourseDTO courseDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var courseModel = mapper.Map<Course>(courseDTO);
                    await courseRepository.Insert(courseModel);
                }

                return Json(new ResponseDTO
                {
                    Message = "The process is successful",
                    IsSuccess = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var courseModel = await courseRepository.GetById(id);
            var courseDTO = mapper.Map<CourseDTO>(courseModel);
            return PartialView(courseDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CourseDTO courseDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var courseModel = mapper.Map<Course>(courseDTO);
                    await courseRepository.Update(courseModel);
                }

                return Json(new ResponseDTO
                {
                    Message = "The process is successful",
                    IsSuccess = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await courseRepository.Delete(id);

                return Json(new ResponseDTO
                {
                    Message = "The process is successful",
                    IsSuccess = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}