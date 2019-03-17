using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class Judge
    {
        private Board board;
        private Player w, b;
        private Figure current = null;
        private Figure target = null;

        public char turn { get; set; } // 0 - white player turn, 1 - black player turn 

        public Judge(ref Board board, ref Player w, ref Player b)
        {
            this.board = board;
            this.w = w;
            this.b = b;

            turn = 'w';
        }

        public bool consider(String request)
        {
            Point fp = new Point(request[0].ToString() + request[1].ToString());
            Point mp = new Point(request[2].ToString() + request[3].ToString());

            current = board.fields[fp.X, fp.Y];

            //if user chose no figure (empty field)
            if (current == null)
                return false;

            //if user chose no its own figure (opponent figure chosen)
            if (current.color != turn)
                return false;

            target = board.fields[mp.X, mp.Y];

            //if user want to move its own figure above its own figure w to w, b to b
            if (target != null && target.color == current.color)
                return false;

            current.generateAllowedMoves();

            if (current.matrix[mp.X, mp.Y])
            {
                board.fields[fp.X, fp.Y] = null;
                current.move(mp);
                board.fields[mp.X, mp.Y] = current;
            }

            if (turn == 'w')
                turn = 'b';
            else
                turn = 'w';

            return true;
        }

        public void hardMove(String request)
        {
            Point fp = new Point(request[0].ToString() + request[1].ToString());
            Point mp = new Point(request[2].ToString() + request[3].ToString());

            current = board.fields[fp.X, fp.Y];

            if (current == null)
                return;

            current.generateAllowedMoves();

            board.fields[fp.X, fp.Y] = null;
            current.move(mp);
            board.fields[mp.X, mp.Y] = current;
        }
    }
}
