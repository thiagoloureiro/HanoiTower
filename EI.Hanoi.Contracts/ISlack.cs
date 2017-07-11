using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Hanoi.Contracts
{
    public interface ISlack
    {
        string Send(string text);
    }
}
