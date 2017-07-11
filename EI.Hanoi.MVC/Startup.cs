using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(EI.Hanoi.MVC.App_Start.Startup))]
namespace EI.Hanoi.MVC.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}