using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class King : Figure
    {
        //castling
        public King(Point p, char c, int id) : base(p, c, id)
        {
            type = 'K';
            value = 900;
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if(pos.X > 0)
            {
                if(pos.Y > 0)
                    if (board.fields[pos.X - 1, pos.Y - 1] == null || board.fields[pos.X - 1, pos.Y - 1].color != color)
                    {
                        matrix[pos.X - 1, pos.Y - 1] = true;
                        moves.Add(String.Concat(pos.coords(), new Point(pos.X - 1, pos.Y - 1).coords()));
                    }   

                if (board.fields[pos.X - 1, pos.Y] == null || board.fields[pos.X - 1, pos.Y].color != color)
                {
                    matrix[pos.X - 1, pos.Y] = true;
                    moves.Add(String.Concat(pos.coords(), new Point(pos.X - 1, pos.Y).coords()));
                }
   
                if(pos.Y < 7)
                    if (board.fields[pos.X - 1, pos.Y + 1] == null || board.fields[pos.X - 1, pos.Y + 1].color != color)
                    {
                        matrix[pos.X - 1, pos.Y + 1] = true;
                        moves.Add(String.Concat(pos.coords(), new Point(pos.X - 1, pos.Y + 1).coords()));
                    }         
            }

            if(pos.Y > 0)
                if (board.fields[pos.X, pos.Y - 1] == null || board.fields[pos.X, pos.Y - 1].color != color)
                {
                    matrix[pos.X, pos.Y - 1] = true;
                    moves.Add(String.Concat(pos.coords(), new Point(pos.X, pos.Y - 1).coords()));
                }
 
            if (pos.Y < 7)
                if (board.fields[pos.X, pos.Y + 1] == null || board.fields[pos.X, pos.Y + 1].color != color)
                {
                    matrix[pos.X, pos.Y + 1] = true;
                    moves.Add(String.Concat(pos.coords(), new Point(pos.X, pos.Y + 1).coords()));
                }
  
            if(pos.X < 7)
            {
                if (pos.Y > 0)
                    if (board.fields[pos.X + 1, pos.Y - 1] == null || board.fields[pos.X + 1, pos.Y - 1].color != color)
                    {
                        matrix[pos.X + 1, pos.Y - 1] = true;
                        moves.Add(String.Concat(pos.coords(), new Point(pos.X + 1, pos.Y - 1).coords()));
                    }
                       
                if (board.fields[pos.X + 1, pos.Y] == null || board.fields[pos.X + 1, pos.Y].color != color)
                {
                    matrix[pos.X + 1, pos.Y] = true;
                    moves.Add(String.Concat(pos.coords(), new Point(pos.X + 1, pos.Y).coords()));
                }
                    
                if (pos.Y < 7)
                    if (board.fields[pos.X + 1, pos.Y + 1] == null || board.fields[pos.X + 1, pos.Y + 1].color != color)
                    {
                        matrix[pos.X + 1, pos.Y + 1] = true;
                        moves.Add(String.Concat(pos.coords(), new Point(pos.X + 1, pos.Y + 1).coords()));
                    }           
            }

            //show();
        }
    }
}
