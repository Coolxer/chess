using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class Board
    {
        public char[,] fields { get; set; }

        public Board()
        {
            fields = new char[8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    fields[i, j] = ' ';
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

                    Console.Write(" " + fields[i, j]);

                    Console.ResetColor();
                }
                Console.WriteLine();      
            }
            Console.WriteLine("---------------------");
        }

        public void createGrid(Figure[] f1, Figure[] f2)
        {
            Console.WriteLine(f1[0].pos.X + " " +  f1[0].pos.Y);

            for (int i = 0; i < f1.Length; i++)
                fields[f1[i].pos.X, f1[i].pos.Y] = f1[i].value;

            for (int i = 0; i < f2.Length; i++)
                fields[f2[i].pos.X, f2[i].pos.Y] = f2[i].value;

            draw();
        }

        public char getField(Point pos)
        {
            return fields[pos.X, pos.Y];
        }

    }
}
