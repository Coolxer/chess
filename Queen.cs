using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Queen : Figure
    {
        public Queen(Point p, char c) : base(p, c)
        {
            value = 'Q';
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if (pos.X < 8)
                for (int i = pos.X + 1; i < 8; i++)
                    matrix[i, pos.Y] = true;

            if(pos.X < 8 && pos.Y < 8)
                for (int i = pos.X + 1, j = pos.Y + 1; i < 8; i++, j++)
                    matrix[i, j] = true;

            if(pos.Y < 8)
                for (int i = pos.Y + 1; i < 8; i++)
                    matrix[pos.X, i] = true;

            if(pos.X > 0 && pos.Y < 8)
                for (int i = pos.X - 1, j = pos.Y + 1; i > 0; i--, j++)
                    matrix[i, j] = true;

            if(pos.X > 0)
                for (int i = pos.X - 1; i > 0; i--)
                    matrix[i, pos.Y] = true;

            if(pos.X > 0 && pos.Y > 0)
                for (int i = pos.X - 1, j = pos.Y - 1; i > 0; i--, j--)
                    matrix[i, j] = true;

            if(pos.Y > 0)
                for (int i = pos.Y - 1; i > 0; i--)
                    matrix[pos.X, i] = true;

            if(pos.X < 8 && pos.Y > 0)
                for (int i = pos.X + 1, j = pos.Y - 1; i < 8; i++, j--)
                    matrix[i, j] = true;

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
