using System;
using System.Threading;

namespace EI.Hanoi.Site
{
    public class TowerOfHanoi
    {
        #region| Properties |

        public readonly int GameId;
        private int numberOfDisks;

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

        public TowerOfHanoi(int gameId, int diskQuantity)
        {
            this.GameId = gameId;
            this.numdiscs = diskQuantity;
        }

        #endregion

        #region| Methods |

        public void movetower(int n, int from, int to, int via, Action<int, int, int, int> callback)
        {
            //if (n == 1)
            //{
            //    callback(GameId, n - 1, from - 1, to - 1);

            //    Thread.Sleep(1000);
            //}
            //else
            //{
            //    movetower(n - 1, from, via, to, callback);
            //    movetower(1, from, to, via, callback);
            //    movetower(n - 1, via, to, from, callback);
            //}
        }

        #endregion
    }
}