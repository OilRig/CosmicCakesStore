
using CosmicCakes.DAL;
using CosmicCakes.DAL.Migrations;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CosmicCakesWebApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();

            var httpException = exception as HttpException;

            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        action = "PageNotFound";
                        break;
                    case 500:
                        action = "Error500";
                        break;
                    default:
                        action = "General";
                        break;
                }

                Response.Redirect($"~/Error/{action}");
            }


        }
    }
}
