using EI.Hanoi.Model;
using System.Collections.Generic;

namespace EI.Hanoi.Contracts
{
    public interface IGame
    {
        Game StartNewGame();

        List<Game> GetHistory();
    }
}