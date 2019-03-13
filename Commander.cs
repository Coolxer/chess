using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Commander
    {
        public int process(String cmd) //returns 0 when there is exit request, 1 valid command, 2 invalid command
        {

            if (cmd.Length == 0)
                return 2;
            else if (cmd == "exit" || cmd == "quit")
                return 0;
            else if (cmd.Length == 4)
                if ((cmd[0] >= 97 && cmd[0] <= 104) && (cmd[1] >= 49 && cmd[1] <= 56) && (cmd[2] >= 97 && cmd[2] <= 104) && (cmd[3] >= 49 && cmd[3] <= 56))
                    return 1;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("invalid command");
            Console.ResetColor();
            return 2;
        }
    }
}
