using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Knight : Figure
    {

        //can flip over other pieces
        public Knight(Point p, char c) : base(p, c)
        {
            if (c == 'w')
                value = 'N';
            else
                value = 'n';
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if (row < 8 && col > 1)
                matrix[row + 1, col - 2] = true;

            if(row < 7 && col > 0)
                matrix[row + 2, col - 1] = true;

            if(row < 8 && col < 7)
                matrix[row + 1, col + 2] = true;

            if(row < 7 && col < 8)
                matrix[row + 2, col + 1] = true;

            if(row > 0 && col < 7)
                matrix[row - 1, col + 2] = true;

            if(row > 1 && col < 8)
                matrix[row - 2, col + 1] = true;

            if(row > 0 && col > 1)
                matrix[row - 1, col - 2] = true;

            if(row > 1 && col > 0)
                matrix[row - 2, col - 1] = true;
        }
    }
}
