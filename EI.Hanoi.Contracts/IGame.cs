using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EI.Hanoi.Model;

namespace EI.Hanoi.Contracts
{
    public interface IGame
    {
        Game StartNewGame();
        List<Game> GetHistory();
    }
}
