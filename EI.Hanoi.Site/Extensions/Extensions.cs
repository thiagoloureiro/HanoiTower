using System.Web;
using EI.Hanoi.Services;

namespace EI.Hanoi.Site.Extensions
{
    public static class Extensions
    {
        public static void Save(this GameService @sender)
        {
            HttpContext.Current.Session["gameServices"] = sender;
        }
    }
}