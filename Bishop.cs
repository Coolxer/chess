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
            value = 'B';
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if (pos.X > 0)
            {
                //left-top
                for (int i = pos.X - 1, j = pos.Y - 1; i > 0; i--, j--)
                    matrix[i, j] = true;

                //right-top
                for (int i = pos.X - 1, j = pos.Y + 1; i > 0; i--, j++)
                    matrix[i, j] = true;
            }

            if(pos.X < 8)
            {
                //right-bottom
                for (int i = pos.X + 1, j = pos.Y + 1; i < 8; i++, j++)
                    matrix[i, j] = true;

                //left-bottom
                for (int i = pos.X + 1, j = pos.Y - 1; i < 8; i++, j--)
                    matrix[i, j] = true;
            }

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
