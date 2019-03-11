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

        private int[] allowedMovements; //top top-right right bottom-right bottom bottom-left left top-left //1 2 3 4 5 6 7 8

        public Figure(Point p)
        {
            pos = p; 
        }

        public abstract void move();
        public abstract void allowMoves();       
    }
}
