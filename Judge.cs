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
        private Figure current;

        private bool turn = false; // 0 - white player turn, 1 - black player turn 

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
            bool allow = true;

            Point fp = new Point(request[0].ToString() + request[1].ToString());
            Point mp = new Point(request[2].ToString() + request[3].ToString());

            if (board.getField(fp) == '')
                return false;

            //for(int i = 0; i < board.fields.Length; i++)
            //{
            //    if(board)
            //}

            return true;

            

        }
    }
}
