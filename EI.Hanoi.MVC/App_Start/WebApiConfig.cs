using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Microsoft.Practices.Unity;
using System.Web.Mvc;
using EI.Hanoi.Contracts;
using EI.Hanoi.Services;

namespace EI.Hanoi.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           
        }
    }    
}
