using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Rook : Figure
    {
        public Rook(Point p, char c) : base(p, c)
        {
            if (c == 'w')
                value = 'R';
            else
                value = 'r';
        }

        public override void move()
        {
            
        }

        public override void allowMoves()
        {
            //top
            if(row < 8)
                for (int i = row + 1; i < 8; i++)
                    matrix[i, col] = true;

            //right
            if(col < 8)
            for (int i = col + 1; i < 8; i++)
                matrix[row, i] = true;

            //down
            if(row > 0)
            for (int i = row - 1; i > 0; i--)
                matrix[i, col] = true;

            //left
            if(row < 8)
            for (int i = col - 1; i > 0; i--)
                matrix[row, i] = true;
        }
    }
}
