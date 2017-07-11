using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EI.Hanoi.Model
{
    public class Game
    {
        #region| Properties |

        public int GameId { get; set; }
        int numberOfDisks;

        public int numdiscs 
        {
            get
            {
                return numberOfDisks;
            }
            set
            {
                if (value > 0)
                    numberOfDisks = value;
            }
        }

        #endregion

        #region| Constructor | 

        public Game(int diskQuantity)
        {
            this.numdiscs = diskQuantity;
        }

        #endregion

        #region| Methods |

        public void movetower(int n, int from, int to, int via, Action<int, int, int, int> callback)
        {
            if (n == 1)
            {
                callback(GameId, n - 1, from - 1, to - 1);

                Thread.Sleep(1000);
            }
            else
            {
                movetower(n - 1, from, via, to, callback);
                movetower(1, from, to, via, callback);
                movetower(n - 1, via, to, from, callback);
            }
        }

        #endregion
    }
}
