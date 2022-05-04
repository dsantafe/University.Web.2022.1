using AutoMapper;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using University.BL.DTOs;

namespace University.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static MapperConfiguration MapperConfiguration { get; private set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MapperConfiguration = MapperConfig.MapperConfiguration();

            MvcHandler.DisableMvcResponseHeader = true;
        }

        protected void Application_PreSendRequestHeaders()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Headers.Remove("Server");
            }
        }
    }
}
