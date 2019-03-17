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
            value = 'P';
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if (firstMove)
            {
                coord();
                if (color == 'w')
                {
                    if(board.fields[pos.X - 1, pos.Y] == null || board.fields[pos.X - 1, pos.Y].color != color)
                        matrix[pos.X - 1, pos.Y] = true;

                    if (board.fields[pos.X - 1, pos.Y] == null && (board.fields[pos.X - 2, pos.Y] == null ||board.fields[pos.X - 2, pos.Y].color != color))
                        matrix[pos.X - 2, pos.Y] = true;
                }
                else
                {
                    if (board.fields[pos.X + 1, pos.Y] == null || board.fields[pos.X + 1, pos.Y].color != color)
                        matrix[pos.X + 1, pos.Y] = true;

                    if (board.fields[pos.X + 2, pos.Y] == null && (board.fields[pos.X + 2, pos.Y] == null || board.fields[pos.X - 2, pos.Y].color != color))
                        matrix[pos.X + 2, pos.Y] = true;
                }

                firstMove = false;
            }
            else
            {
                if(pos.X < 8)
                {
                    if (color == 'w')
                    {
                        if (board.fields[pos.X - 1, pos.Y] == null || board.fields[pos.X - 1, pos.Y].color != color)
                            matrix[pos.X - 1, pos.Y] = true;
                    }
                    else
                    {
                        if (board.fields[pos.X + 1, pos.Y] == null || board.fields[pos.X + 1, pos.Y].color != color)
                            matrix[pos.X + 1, pos.Y] = true;
                    }
                        
                }
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
