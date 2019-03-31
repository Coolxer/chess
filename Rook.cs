using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Rook : Figure
    {
        public Rook(ref Board board, Point p, char c, int id) : base(ref board, p, c, id)
        {
            type = 'R';

            if (c == 'w')
                value = 50;
            else
                value = -50;
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

                    moves.Add(String.Concat(pos.coords(), new Point(i, pos.Y).coords()));
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

                    moves.Add(String.Concat(pos.coords(), new Point(pos.X, i).coords()));
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

                    moves.Add(String.Concat(pos.coords(), new Point(i, pos.Y).coords()));
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

                    moves.Add(String.Concat(pos.coords(), new Point(pos.X, i).coords()));
                }
            }

            //show();
        }
    }
}
