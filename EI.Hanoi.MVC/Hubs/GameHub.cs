using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

using EI.Hanoi.Contracts;
using EI.Hanoi.Services;

namespace EI.Hanoi.MVC
{
    [HubName("gameHub")]
    public class GameHub : Hub
    {
        public void Send(string gameId)
        {            
            Task.Run(() => StartGame());
        }

        private void StartGame()
        {
            var game = new TowerOfHanoi(0,3);

            game.movetower(game.numdiscs, 1, 3, 2, (GameId, disk, from, to) => 
            {                    
                // Call the addNewMessageToPage method to update clients.
                Clients.All.addNewMessageToPage(GameId, from, to, disk);
            });

            // Call the addNewMessageToPage method to update clients.
            // Clients.All.addNewMessageToPage("teste", $"GameId:{ gameId.ToString() } - current: { i.ToString()}");

           
            
        }
    }
}