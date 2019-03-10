using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Board
    {
        private char[,] poles;

        public Board()
        {
            poles = new char[8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    poles[i, j] = '.';
        }

        public void draw()
        {   
            Console.WriteLine("-----------------");
            for(int i = 0; i < 8; i++ )
            {
                for(int j = 0; j < 8; j++)
                    Console.Write(" " + poles[i, j]);
                Console.WriteLine();      
            }
            Console.WriteLine("-----------------");
        }

    }
}
