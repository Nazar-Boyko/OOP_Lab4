using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4.ConsoleManager.Base
{
    public interface ICommand
    {

        void Execute();

        string GetCommandInfo();

    }
}
