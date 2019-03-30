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
        public Knight(Point p, char c, int id) : base(p, c, id)
        {
            type = 'N';
            value = 30;
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if(pos.X > 0)
            {
                if(pos.Y > 0)
                {
                    if(pos.Y > 1)
                        if (board.fields[pos.X - 1, pos.Y - 2] == null || board.fields[pos.X - 1, pos.Y - 2].color != color)
                        {
                            matrix[pos.X - 1, pos.Y - 2] = true;
                            moves.Add(String.Concat(pos.coords(), new Point(pos.X - 1, pos.Y - 2).coords()));
                        }

                    if(pos.X > 1)
                        if (board.fields[pos.X - 2, pos.Y - 1] == null || board.fields[pos.X - 2, pos.Y - 1].color != color)
                        {
                            matrix[pos.X - 2, pos.Y - 1] = true;
                            moves.Add(String.Concat(pos.coords(), new Point(pos.X - 2, pos.Y - 1).coords()));
                        }        
                }

                if (pos.Y < 7)
                {
                    if (pos.Y < 6)
                        if (board.fields[pos.X - 1, pos.Y + 2] == null || board.fields[pos.X - 1, pos.Y + 2].color != color)
                        {
                            matrix[pos.X - 1, pos.Y + 2] = true;
                            moves.Add(String.Concat(pos.coords(), new Point(pos.X - 1, pos.Y + 2).coords()));
                        }    

                    if (pos.X > 1)
                        if (board.fields[pos.X - 2, pos.Y + 1] == null || board.fields[pos.X - 2, pos.Y + 1].color != color)
                        {
                            matrix[pos.X - 2, pos.Y + 1] = true;
                            moves.Add(String.Concat(pos.coords(), new Point(pos.X - 2, pos.Y + 1).coords()));
                        }            
                }
            }

            if (pos.X < 7)
            {
                if (pos.Y > 0)
                {
                    if (pos.Y > 1)
                        if (board.fields[pos.X + 1, pos.Y - 2] == null || board.fields[pos.X + 1, pos.Y - 2].color != color)
                        {
                            matrix[pos.X + 1, pos.Y - 2] = true;
                            moves.Add(String.Concat(pos.coords(), new Point(pos.X + 1, pos.Y - 2).coords()));
                        }  

                    if (pos.X > 1)
                        if (board.fields[pos.X + 2, pos.Y - 1] == null || board.fields[pos.X + 2, pos.Y - 1].color != color)
                        {
                            matrix[pos.X + 2, pos.Y - 1] = true;
                            moves.Add(String.Concat(pos.coords(), new Point(pos.X + 2, pos.Y - 1).coords()));
                        }            
                }

                if (pos.Y < 7)
                {
                    if (pos.Y < 6)
                        if (board.fields[pos.X + 1, pos.Y + 2] == null || board.fields[pos.X + 1, pos.Y + 2].color != color)
                        {
                            matrix[pos.X + 1, pos.Y + 2] = true;
                            moves.Add(String.Concat(pos.coords(), new Point(pos.X + 1, pos.Y + 2).coords()));
                        }
                            
                    if (pos.X > 1)
                        if (board.fields[pos.X + 2, pos.Y + 1] == null || board.fields[pos.X + 2, pos.Y + 1].color != color)
                        {
                            matrix[pos.X + 2, pos.Y + 1] = true;
                            moves.Add(String.Concat(pos.coords(), new Point(pos.X + 2, pos.Y + 1).coords()));
                        }         
                }
            }

            //show();
        }
    }
}
