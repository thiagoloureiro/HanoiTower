using Hanoi.Contracts;
using System.Web.Mvc;

namespace Hanoi.Site.Controllers
{
    public class HomeController : Controller
    {
        #region | Actions |

        public ActionResult Index()
        {
            // _slackService.Send("Firt message from Hanoi Tower");

            // gameHub.Clients.All.addNewMessageToPage(0, 1, 3, 1);

            return View();
        }

        #endregion | Actions |
    }
}