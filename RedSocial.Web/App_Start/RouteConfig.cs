using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RedSocial.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            );

            routes.MapRoute(
               name: "enviarsolicitud",
               url: "{controller}/{action}/{id}/{param1}/{param2}",
               defaults: new { controller = "SolicitudAmistad", action = "EnviarSolicitud", id = 0, 
                   idereceptor = UrlParameter.Optional, nombreemi = UrlParameter.Optional}

           );

        }
    }
}
