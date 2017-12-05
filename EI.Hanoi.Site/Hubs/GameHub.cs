using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace Hanoi.Site.Hubs
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
            var game = new TowerOfHanoi(0, 3);

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