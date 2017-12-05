using Hanoi.Contracts;
using Hanoi.Model;
using System.Collections.Generic;

namespace Hanoi.Services
{
    public class GameService : IGame
    {
        #region| Properties |

        private List<Game> games = new List<Game>();

        #endregion

        #region| Methods |

        public List<Game> GetHistory()
        {
            return new List<Game>();
        }

        public Game StartNewGame(int discs)
        {
            var oGame = new Game(discs) { GameId = games.Count };

            games.Add(oGame);

            return oGame;
        }

        #endregion
    }
}