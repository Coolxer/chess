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
            if (c == 'w')
                value = 'Q';
            else
                value = 'q';
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if (row < 8)
                for (int i = row + 1; i < 8; i++)
                    matrix[i, col] = true;

            if(row < 8 && col < 8)
                for (int i = row + 1, j = col + 1; i < 8; i++, j++)
                    matrix[i, j] = true;

            if(col < 8)
                for (int i = col + 1; i < 8; i++)
                    matrix[row, i] = true;

            if(row > 0 && col < 8)
                for (int i = row - 1, j = col + 1; i > 0; i--, j++)
                    matrix[i, j] = true;

            if(row > 0)
                for (int i = row - 1; i > 0; i--)
                    matrix[i, col] = true;

            if(row > 0 && col > 0)
                for (int i = row - 1, j = col - 1; i > 0; i--, j--)
                    matrix[i, j] = true;

            if(col > 0)
                for (int i = col - 1; i > 0; i--)
                    matrix[row, i] = true;

            if(row < 8 && col > 0)
                for (int i = row + 1, j = col - 1; i < 8; i++, j--)
                    matrix[i, j] = true;
        }
    }
}
