using System.Web.Mvc;
using System.Web.Routing;

namespace GolfTalk
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Register",
               "register",
               new { controller = "Account", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
             "Login",
             "login",
             new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
             "Scoreboard",
             "scoreboard/{teamId}",
             new { controller = "Scoreboard", action = "Index" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}