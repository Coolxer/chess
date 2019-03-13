using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Pawn : Figure
    {
        private bool firstMove = true;
        //special en pasant     promotion
        public Pawn(Point p, char c) : base(p, c)
        {
            if (c == 'w')
                value = 'P';
            else
                value = 'p';
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if (firstMove)
            {
                if (color == 'w')
                {
                    matrix[row + 1, col] = true;
                    matrix[row + 2, col] = true;
                }
                else
                {
                    matrix[row - 1, col] = true;
                    matrix[row - 2, col] = true;
                }
                firstMove = false;
            }
            else
            {
                if(row < 8)
                {
                    if (color == 'w')
                        matrix[row + 1, col] = true;
                    else
                        matrix[row - 1, col] = true;
                }
            }   
        }
    }
}
