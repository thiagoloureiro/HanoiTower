using System;
using System.Web.Http;
using System.Web.Mvc;
using EI.Hanoi.Contracts;
using EI.Hanoi.Services;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace EI.Hanoi.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ISlack, SlackService>();
            container.RegisterType<IGame, GameService>();

            // Set the unity based on the MVC5 dependencies
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // Set the unity based on the WebAPI dependencies
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}