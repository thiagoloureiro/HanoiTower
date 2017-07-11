using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EI.Hanoi.Contracts;
using EI.Hanoi.Model;
using EI.Hanoi.Services;
using Microsoft.AspNet.SignalR;

namespace EI.Hanoi.MVC.Controllers
{
    public class GameAPIController : ApiController
    {
        #region| Properties  |

        private readonly ISlack _slackService;

        #endregion

        #region| Constructor |

        public GameAPIController(ISlack slackService)
        {
            _slackService = slackService;
        }

        #endregion


        private IHubContext gameHub = GlobalHost.ConnectionManager.GetHubContext<GameHub>();

        [HttpGet]
        [Route("api/game")]
        public HttpResponseMessage Start()
        {
            var gameServices = GetGameService();

            var game = gameServices.StartNewGame();

            Task.Run(() => Start(game));

            gameServices.Save();

            // Send Slack notification message
            NotifySlack($"The game # { game.GameId.ToString() } has been started.");

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpGet]
        [Route("api/gamereset")]
        public HttpResponseMessage Reset()
        {
            HttpContext.Current.Session.Remove("gameServices");

            NotifySlack("All games data have been reseted");

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        private void InitializeGame()
        {
            var gameServices = GetGameService();

            var game = gameServices.StartNewGame();

            Start(game);

            gameServices.Save();
        }

        private GameService GetGameService()
        {
            var gameServices = HttpContext.Current.Session["gameServices"] as GameService;

            if (gameServices == null)
            {
                gameServices = new GameService();
            }

            return gameServices;
        }

        private void Start(Game game)
        {
            game.movetower(game.numdiscs, 1, 3, 2, (GameId, disk, from, to) =>
            {
                // Call the addNewMessageToPage method to update clients.
                gameHub.Clients.All.addNewMessageToPage(GameId, from, to, disk);

            });
        }

        private void NotifySlack(string message)
        {
            _slackService.Send(message);
        }
    }   
}
