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

        public bool[,] matrix; //top top-right right bottom-right bottom bottom-left left top-left //1 2 3 4 5 6 7 8

        public int row { get; set; }
        public int col { get; set; }

        public Figure(Point p, char c)
        {
            pos = p;
            color = c;

            matrix = new bool[8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    matrix[i, j] = false;

            row = pos.Y;
            col = pos.X;
        }

        public abstract void move();
        public abstract void allowMoves();       
    }
}
