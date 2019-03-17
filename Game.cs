using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Game
    {
        private Commander cmd;

        private Board board;
        private Player w;
        private Player b;

        private Judge judge;

        bool redraw = true;

        private int[,] table;

        public Game()
        {
            cmd = new Commander();
            board = new Board();
            w = new Player('w');
            b = new Player('b');

            //Judge.Instance.init(ref board, ref w, ref b);

            judge = new Judge(ref board, ref w, ref b);

            //table = new int[8, 8];

            //for(int i = 0; i < 8; i++)
            //{
            //    for(int j = 0; j < 8; j++)
            //    {
            //        table[i, j] = (i * 8) + j;
            //        Console.Write(" " + table[i, j]);
            //    }
            //    Console.WriteLine();
            //}
        }

        public void run()
        {
            while (true)
            {
                if (redraw)
                {
                    //Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Current turn: " + judge.turn);
                    board.createGrid(w.figures, b.figures);
                    redraw = false;
                }

                String call = Console.ReadLine();
                int code = cmd.process(call);

                if (code == 0)
                    break;
                else if (code == 1)
                {
                    if (judge.consider(call))
                        redraw = true;
                }
                    //Judge.Instance.consider(call);      
            }
        }
    }
}
