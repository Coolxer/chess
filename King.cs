using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class King : Figure
    {
        //castling
        public King(Point p, char c) : base(p, c)
        {
            if (c == 'w')
                value = 'K';
            else
                value = 'k';
        }

        public override void move()
        {
            row = pos.X;
            col = pos.Y;
        }

        public override void allowMoves()
        {
            if(row < 8 && col > 0)
                matrix[row + 1, col - 1] = true;

            if(row < 8)
                matrix[row + 1, col] = true;

            if(row < 8 && col < 8 )
                matrix[row + 1, col + 1] = true;

            if(col > 0)
                matrix[row, col - 1] = true;

            if(col < 8)
                matrix[row, col + 1] = true;

            if(row > 0 && col > 0)
                matrix[row - 1, col - 1] = true;

            if(row > 0)
                matrix[row - 1, col] = true;

            if(row > 0 && col < 8)
                matrix[row - 1, col + 1] = true;
        }
    }
}
