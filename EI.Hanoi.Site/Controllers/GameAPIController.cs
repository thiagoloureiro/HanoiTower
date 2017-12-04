﻿using EI.Hanoi.Contracts;
using EI.Hanoi.Model;
using EI.Hanoi.Services;
using EI.Hanoi.Site.Extensions;
using EI.Hanoi.Site.Hubs;
using Microsoft.AspNet.SignalR;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace EI.Hanoi.Site.Controllers
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

            var game = gameServices.StartNewGame(5);

            Task.Run(() => Start(game));

            gameServices.Save();

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpGet]
        [Route("api/gamereset")]
        public HttpResponseMessage Reset()
        {
            HttpContext.Current.Session.Remove("gameServices");

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        private void InitializeGame()
        {
            var gameServices = GetGameService();

            var game = gameServices.StartNewGame(5);

            Start(game);

            gameServices.Save();
        }

        private GameService GetGameService()
        {
            if (!(HttpContext.Current.Session["gameServices"] is GameService gameServices))
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
    }
}