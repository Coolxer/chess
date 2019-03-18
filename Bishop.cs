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
                    }
                }
            }

            show();
        }
    }
}
