using EI.Hanoi.Contracts;
using EI.Hanoi.Services;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace EI.Hanoi.Site
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IGame, GameService>();

            // Set the unity based on the MVC5 dependencies
            System.Web.Mvc.DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            // Set the unity based on the WebAPI dependencies
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}