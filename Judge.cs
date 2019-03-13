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

        public void Asdasd(ref Board board, ref Player w, ref Player b)
        {

        }

        public void consider(String request)
        {
            String fp, mp;
            fp = request[0].ToString() + request[1].ToString();
            mp = request[2].ToString() + request[3].ToString();



        }
    }
}
