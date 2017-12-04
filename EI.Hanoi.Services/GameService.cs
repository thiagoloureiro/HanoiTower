﻿using EI.Hanoi.Contracts;
using EI.Hanoi.Model;
using System.Collections.Generic;
using System.Linq;

namespace EI.Hanoi.Services
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

        public Game StartNewGame()
        {
            var oGame = new Game(3);

            oGame.GameId = games.Count();

            games.Add(oGame);

            return oGame;
        }

        #endregion
    }
}