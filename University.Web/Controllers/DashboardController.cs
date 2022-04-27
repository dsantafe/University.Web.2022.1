using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using University.BL.DTOs;

namespace University.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Donut()
        {
            return View();
        }

        public async Task<ActionResult> DonutJson(int id)
        {
            var data = new List<DonutExampleDTO>();
            switch (id)
            {
                case 1:
                    data = Report1();
                    break;
                case 2:
                    data = Report2();
                    break;
                default:
                    break;
            }

            var dataJson = JsonConvert.SerializeObject(data);
            return Json(dataJson, JsonRequestBehavior.AllowGet);
        }

        private List<DonutExampleDTO> Report1()
        {
            var data = new List<DonutExampleDTO>();
            data.Add(new DonutExampleDTO { Value = 70, Label = "Java" });
            data.Add(new DonutExampleDTO { Value = 30, Label = "Angular" });
            return data;
        }
        private List<DonutExampleDTO> Report2()
        {
            var data = new List<DonutExampleDTO>();
            data.Add(new DonutExampleDTO { Value = 70, Label = "React" });
            data.Add(new DonutExampleDTO { Value = 30, Label = "Node" });
            return data;
        }

        public ActionResult Bar()
        {
            return View();
        }
    }
}