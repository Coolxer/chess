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
            value = 'R';
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            //top
            if (pos.X > 0)
                for (int i = pos.X - 1; i >= 0; i--)
                    matrix[i, pos.Y] = true;

            //right
            if(pos.Y < 8)
                for (int i = pos.Y + 1; i < 8; i++)
                    matrix[pos.X, i] = true;

            //down
            if(pos.X < 8)
                for (int i = pos.X + 1; i < 8; i++)
                    matrix[i, pos.Y] = true;

            //left
            if(pos.X > 0)
                for (int i = pos.X - 1; i >= 0; i--)
                    matrix[pos.X, i] = true;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j])
                        Console.Write('1');
                    else
                        Console.Write('0');
                }

                Console.WriteLine();
            }
        }
    }
}
