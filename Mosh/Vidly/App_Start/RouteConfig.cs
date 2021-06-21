﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //exemplo de rota customizada
            //routes.MapRoute("MoviesByReleaseDate", "movies/released/{year}/{month}", new { controller = "movies", action = "ByReleaseDate" }, new { year = @"\d{4}", month = @"\d{2}" });
            //routes.MapRoute("MoviesByReleaseDate2", "movies/released", new { controller = "movies", action = "ByReleaseDate" });

            //rota customizada com atributo
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
