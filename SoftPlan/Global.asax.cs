using System;
using System.Web.Http;
using System.Web.Routing;

namespace SoftPlan
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute(
                name: "Juros",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    id = System.Web.Http.RouteParameter.Optional
                }
            );
        }
    }
}