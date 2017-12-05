using Hanoi.Model;
using System.Collections.Generic;

namespace Hanoi.Contracts
{
    public interface IGame
    {
        Game StartNewGame(int discs);

        List<Game> GetHistory();
    }
}