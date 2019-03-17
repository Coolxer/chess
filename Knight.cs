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
            value = 'N';
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if (pos.X < 7 && pos.Y < 8)
                matrix[pos.X - 2, pos.Y + 1] = true;

            if (pos.X < 8 && pos.Y < 7)s
                matrix[pos.X - 1, pos.Y + 2] = true;

            if(pos.X > 1 && pos.Y < 8)
                matrix[pos.X + 2, pos.Y + 1] = true;

            if(pos.X > 0 && pos.Y < 7)
                matrix[pos.X + 1, pos.Y + 2] = true;

            if(pos.X > 1 && pos.Y > 0)
                matrix[pos.X + 2, pos.Y - 1] = true;

            if(pos.X > 0 && pos.Y > 1)
                matrix[pos.X + 1, pos.Y - 2] = true;

            if(pos.X < 7 && pos.Y > 0)
                matrix[pos.X - 2, pos.Y - 1] = true;

            if(pos.X < 8 && pos.Y > 1)
                matrix[pos.X - 1, pos.Y - 2] = true;

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
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
