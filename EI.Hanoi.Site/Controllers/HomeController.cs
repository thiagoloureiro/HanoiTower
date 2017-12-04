using EI.Hanoi.Contracts;
using System.Web.Mvc;

namespace EI.Hanoi.Site.Controllers
{
    public class HomeController : Controller
    {
        #region| Properties  |

        private readonly ISlack _slackService;

        #endregion

        #region| Constructor |

        public HomeController(ISlack slackService)
        {
            _slackService = slackService;
        }

        #endregion

        #region | Actions |

        public ActionResult Index()
        {
            // _slackService.Send("Firt message from Hanoi Tower");

            // gameHub.Clients.All.addNewMessageToPage(0, 1, 3, 1);

            return View();
        }

        #endregion
    }
}