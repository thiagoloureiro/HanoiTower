using System.Web;
using Hanoi.Services;

namespace Hanoi.Site.Extensions
{
    public static class Extensions
    {
        public static void Save(this GameService @sender)
        {
            HttpContext.Current.Session["gameServices"] = sender;
        }
    }
}