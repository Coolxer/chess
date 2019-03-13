using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Bishop : Figure
    {
        public Bishop(Point p, char c) : base(p, c)
        {
            if (c == 'w')
                value = 'B';
            else
                value = 'b';
        }

        public override void move()
        {

        }

        public override void allowMoves()
        {   
            if(row < 8)
            {
                //left-top
                for (int i = row + 1, j = col - 1; i < 8; i++, j--)
                    matrix[i, j] = true;

                //right-top
                for (int i = row + 1, j = col + 1; i < 8; i++, j++)
                    matrix[i, j] = true;
            }

            if(row > 0)
            {
                //right-bottom
                for (int i = row - 1, j = col + 1; i > 0; i--, j++)
                    matrix[i, j] = true;

                //left-bottom
                for (int i = row - 1, j = col - 1; i > 0; i--, j--)
                    matrix[i, j] = true;
            }   
        }
    }
}
