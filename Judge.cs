using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public sealed class Judge
    {
        private Board board;
        private Player w, b;
        private Figure current = null;

        private char turn = 'w'; // 0 - white player turn, 1 - black player turn 

        private static Judge judge;

        private Judge() {}

        public static Judge Instance
        {
            get
            {
                if (judge == null)
                    judge = new Judge();

                return judge;
            }
        }

        public void init(ref Board board, ref Player w, ref Player b)
        {
            this.board = board;
            this.w = w;
            this.b = b;
        }

        public bool consider(String request)
        {
            Point fp = new Point(request[0].ToString() + request[1].ToString());
            Point mp = new Point(request[2].ToString() + request[3].ToString());

            current = board.getField(fp);

            if (current == null || current.color != turn) //if user chose clear field to move or his opponent figure
                return false;

            if (board.fields[mp.X, mp.Y].color == current.color) //if user want to move its own figure above its own figure w to w, b to b
                return false;

            current.generateAllowedMoves();

            if (current.matrix[mp.X, mp.Y])
            {
                board.fields[fp.X, fp.Y] = null;
                current.move(mp);
            }
            return true;
        }
    }
}
