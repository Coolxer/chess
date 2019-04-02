using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class Board
    {
        public Figure[,] fields { get; set; }

        public Board()
        {
            fields = new Figure [8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    fields[i, j] = null;
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
                        if (j % 2 == 0)
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        else
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        if (j % 2 == 0)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        else
                            Console.BackgroundColor = ConsoleColor.DarkGray;       
                    }

                    if (fields[i, j] == null)
                        Console.Write("  ");
                    else
                    {
                        if (fields[i, j].color == 'w')
                            Console.ForegroundColor = ConsoleColor.White;
                        else
                            Console.ForegroundColor = ConsoleColor.Black;

                        Console.Write(" " + fields[i, j].type);
                    }      
                    Console.ResetColor();
                }
                Console.WriteLine();      
            }
            Console.WriteLine("---------------------");
        }

        public void createGrid(List <Figure> f1, List <Figure> f2)
        {
            foreach(Figure f in f1)
            {
                if(f != null)
                    fields[f.pos.X, f.pos.Y] = f;
            }

            foreach (Figure f in f2)
            {
                if (f != null)
                    fields[f.pos.X, f.pos.Y] = f;
            }

            draw();
        }

        public void reset()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    fields[i, j] = null;
        }
    }
}
