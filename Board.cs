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
        private ConsoleColor background;

        public Board()
        {
            poles = new char[8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    poles[i, j] = ' ';
        }

        public void draw()
        {   
            Console.WriteLine("---------------------");
            Console.WriteLine("    a b c d e f g h ");
            for (int i = 0, x = 8; i < 8; i++, x-- )
            {
                Console.Write(" " + x.ToString() + " ");
                for (int j = 0; j < 8; j++)
                {
                    if(i % 2 == 0)
                    {
                        if(j % 2 == 0)
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        else
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        if (j % 2 != 0)
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        else
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }

                    Console.Write(" " + poles[i, j]);

                    Console.ResetColor();
                }
                Console.WriteLine();      
            }
            Console.WriteLine("---------------------");
        }

    }
}
