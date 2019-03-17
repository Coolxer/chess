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
        public char value { get; set; }
        public char color { get; set; }

        public Board board { get; }

        public bool[,] matrix; //top top-right right bottom-right bottom bottom-left left top-left //1 2 3 4 5 6 7 8

        public Figure(Point p, char c)
        {
            pos = p;
            color = c;

            matrix = new bool[8, 8];

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
        }

        public void coord()
        {
            Console.WriteLine("[ " + pos.X + " , " + pos.Y + " ]");
        }

        public abstract void generateAllowedMoves();         
    }
}
