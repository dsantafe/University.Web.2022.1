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

        public async Task<ActionResult> DonutJson()
        {
            var data = new List<DonutExampleDTO>();
            data.Add(new DonutExampleDTO { Value = 70, Label = "Java" });
            data.Add(new DonutExampleDTO { Value = 30, Label = "Angular" });

            var dataJson = JsonConvert.SerializeObject(data);

            return Json(dataJson, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Bar()
        {
            return View();
        }
    }
}