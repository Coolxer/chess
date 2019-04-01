using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public abstract class Figure
    {
        public Point pos { get; set; }
        public int value { get; set; }
        public char type { get; set; }
        public char color { get; set; }
        public int id { get; set; }

        public Board board { get; set; }

        public bool[,] matrix;

        public List<String> moves;

        public Figure() { }

        public Figure(ref Board board, Point p, char c)
        {
            pos = p;
            color = c;

            this.board = board;

            matrix = new bool[8, 8];

            moves = new List<string>();

            clearMatrix();
        }

        public void init(ref Board board)
        {
            this.board = board;
        }

        public void move(Point p)
        {
            pos = p;
        }

        public void clearMatrix()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    matrix[i, j] = false;

            moves.Clear();
        }

        public abstract void generateAllowedMoves();      
        
        public void show()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write('1');
                    }

                    else
                    {
                        Console.ResetColor();
                        Console.Write('0');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
