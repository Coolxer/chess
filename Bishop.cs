using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Bishop : Figure
    {
        public Bishop(ref Board board, Point p, char c) : base(ref board, p, c)
        {
            type = 'B';

            if (c == 'w')
                value = 30;
            else
                value = -30;
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if (pos.X > 0)
            {
                if(pos.Y > 0)
                {
                    //left-top
                    for (int i = pos.X - 1, j = pos.Y - 1; i >= 0 ; i--, j--)
                    {
                        if (j < 0)
                            break;

                        if (board.fields[i, j] != null && board.fields[i, j].color == color)
                            break;

                        matrix[i, j] = true;

                        moves.Add(String.Concat(pos.coords(), new Point(i, j).coords()));

                        if (board.fields[i, j] != null && board.fields[i, j].color != color)
                            break;
                    } 
                }

                if(pos.Y < 7)
                {
                    //fight-top
                    for (int i = pos.X - 1, j = pos.Y + 1; i >= 0; i--, j++)
                    {
                        if (j > 7)
                            break;

                        if (board.fields[i, j] != null && board.fields[i, j].color == color)
                            break;

                        matrix[i, j] = true;

                        moves.Add(String.Concat(pos.coords(), new Point(i, j).coords()));

                        if (board.fields[i, j] != null && board.fields[i, j].color != color)
                            break;
                    }
                } 
            }

            if (pos.X < 7 )
            {
                if (pos.Y > 0)
                {
                    //left-top
                    for (int i = pos.X + 1, j = pos.Y - 1; i <= 7 ; i++, j--)
                    {
                        if (j < 0)
                            break;

                        if (board.fields[i, j] != null && board.fields[i, j].color == color)
                            break;

                        matrix[i, j] = true;

                        moves.Add(String.Concat(pos.coords(), new Point(i, j).coords()));

                        if (board.fields[i, j] != null && board.fields[i, j].color != color)
                            break;
                    }
                }

                if (pos.Y < 7)
                {
                    //fight-top
                    for (int i = pos.X + 1, j = pos.Y + 1; i <= 7; i++, j++)
                    {
                        if (j > 7)
                            break;

                        if (board.fields[i, j] != null && board.fields[i, j].color == color)
                            break;

                        matrix[i, j] = true;

                        moves.Add(String.Concat(pos.coords(), new Point(i, j).coords()));

                        if (board.fields[i, j] != null && board.fields[i, j].color != color)
                            break;
                    }
                }
            }

            //show();
        }
    }
}
