using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Queen : Figure
    {
        public Queen(ref Board board, Point p, char c) : base(ref board, p, c)
        {
            type = 'Q';

            if (c == 'w')
                value = 90;
            else
                value = -90;
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if(pos.X > 0)
            {
                if (pos.Y > 0)
                {
                    for (int i = pos.X - 1, j = pos.Y -1; i >= 0; i--, j--)
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

                for(int i = pos.X - 1; i >= 0; i--)
                {
                    if (board.fields[i, pos.Y] != null && board.fields[i, pos.Y].color == color)
                        break;

                    matrix[i, pos.Y] = true;

                    moves.Add(String.Concat(pos.coords(), new Point(i, pos.Y).coords()));

                    if (board.fields[i, pos.Y] != null && board.fields[i, pos.Y].color != color)
                        break;
                }

                if (pos.Y < 7)
                {
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


            if(pos.Y > 0)
            {
                for(int j = pos.Y - 1; j >= 0; j--)
                {
                    if (board.fields[pos.X, j] != null && board.fields[pos.X, j].color == color)
                        break;

                    matrix[pos.X, j] = true;

                    moves.Add(String.Concat(pos.coords(), new Point(pos.X, j).coords()));

                    if (board.fields[pos.X, j] != null && board.fields[pos.X, j].color != color)
                        break;
                }
            }

            if (pos.Y < 7)
            {
                for (int j = pos.Y + 1; j <= 7; j++)
                {
                    if (board.fields[pos.X, j] != null && board.fields[pos.X, j].color == color)
                        break;

                    matrix[pos.X, j] = true;

                    moves.Add(String.Concat(pos.coords(), new Point(pos.X, j).coords()));

                    if (board.fields[pos.X, j] != null && board.fields[pos.X, j].color != color)
                        break;
                }
            }

            if(pos.X < 7)
            {
                if(pos.Y < 7)
                {
                    for(int i = pos.X + 1, j = pos.Y + 1; i <= 7; i++, j++)
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

                for (int i = pos.X + 1; i <= 7; i++)
                {
                    if (board.fields[i, pos.Y] != null && board.fields[i, pos.Y].color == color)
                        break;

                    matrix[i, pos.Y] = true;

                    moves.Add(String.Concat(pos.coords(), new Point(i, pos.Y).coords()));

                    if (board.fields[i, pos.Y] != null && board.fields[i, pos.Y].color != color)
                        break;
                }

                if(pos.Y > 0)
                {
                    for (int i = pos.X + 1, j = pos.Y - 1; i <= 7; i++, j--)
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

                //show();
            }
        }
    }
}
