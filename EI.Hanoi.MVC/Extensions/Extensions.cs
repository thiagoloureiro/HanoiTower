using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EI.Hanoi.Services;

namespace EI.Hanoi.MVC
{
    public static class Extensions
    {
        public static void Save(this GameService @sender)
        {
            HttpContext.Current.Session["gameServices"] = sender;
        }
    }
}