using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Player
    {
        private ConsoleColor color;

        public Player(char p)
        {
            if (p == 'w')
                color = ConsoleColor.White;
            else if (p == 'b')
                color = ConsoleColor.Blue;
        }
    }
}
