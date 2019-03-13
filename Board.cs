﻿using System;
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
                    if (fields[i, j] == null)
                        Console.Write("  ");
                    else
                        Console.Write(" " + fields[i, j].value);

                    Console.ResetColor();
                }
                Console.WriteLine();      
            }
            Console.WriteLine("---------------------");
        }

        public void createGrid(Figure[] f1, Figure[] f2)
        {
            for (int i = 0; i < f1.Length; i++)
                fields[f1[i].pos.X, f1[i].pos.Y] = f1[i];

            for (int i = 0; i < f2.Length; i++)
                fields[f2[i].pos.X, f2[i].pos.Y] = f2[i];

            draw();
        }

        public Figure getField(Point pos)
        {
            return fields[pos.X, pos.Y];
        }

    }
}
