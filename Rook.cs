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
            {
                for (int i = pos.X - 1; i >= 0; i--)
                {
                    if (board.fields[i, pos.Y] != null && board.fields[i, pos.Y].color == color)
                        break;

                    matrix[i, pos.Y] = true;
                }   
            }
                

            //right
            if(pos.Y < 7)
            {
                for (int i = pos.Y + 1; i <= 7; i++)
                {
                    if (board.fields[pos.X, i] != null && board.fields[pos.X, i].color == color)
                        break;

                    matrix[pos.X, i] = true;
                }     
            }
                

            //down
            if(pos.X < 7)
            {
                for (int i = pos.X + 1; i <= 7; i++)
                {
                    if (board.fields[i, pos.Y] != null && board.fields[i, pos.Y].color == color)
                        break;

                    matrix[i, pos.Y] = true;
                }         
            }
                

            //left
            if(pos.X > 0)
            {
                for (int i = pos.X - 1; i >= 0; i--)
                {
                    if (board.fields[pos.X, i] != null && board.fields[pos.X, i].color == color)
                        break;

                    matrix[pos.X, i] = true;
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
