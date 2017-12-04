using EI.Hanoi.Model;
using System.Collections.Generic;

namespace EI.Hanoi.Contracts
{
    public interface IGame
    {
        Game StartNewGame(int discs);

        List<Game> GetHistory();
    }
}