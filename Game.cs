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

        private bool redraw = true;

        private int callback;

        public Game()
        {
            cmd = new Commander();

            reset();
        }

        private void reset()
        {
            board = new Board();
            w = new Player('w', ref board);
            b = new Player('b', ref board);

            for (int i = 0; i < 16; i++)
            {
                w.figures[i].init(ref board);
                b.figures[i].init(ref board);
            }

            //Judge.Instance.init(ref board, ref w, ref b);

            judge = new Judge(ref board, ref w, ref b);

            redraw = true;
        }

        public void run()
        {
            while (true)
            {
                if (redraw)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Current turn: " + judge.turn);

                    board.createGrid(w.figures, b.figures);
                    redraw = false;
                }

                //callback = judge.rating(b.randomize());
                if (judge.ai && judge.turn == 'b')
                {
                    //callback = judge.rating(b.randomize());
                    //callback = judge.rating(b.calcBestMoveOne());

                    b.calcBestMoveOne();

                    callback = judge.rating(b.bestMove);
                }   
                else
                {
                    String call = Console.ReadLine();
                    int code = cmd.process(call);

                    if (code == 0)
                        break;
                    else if (code == 3)
                        reset();
                    else if (code == 4)
                        judge.helpMe(call);
                    else if (code == 10)
                        judge.ai = true;
                    else if (code == 1)
                        callback = judge.rating(call);
                }
                
                if (callback == 1)
                {
                    redraw = true;
                    callback = 0;
                } 
                else if (callback == 2)
                {
                    Console.Clear();
                    Console.WriteLine("End of the game! " + judge.turn + " win!");
                    Console.WriteLine();
                    Console.WriteLine("Type quit to close OR reset to play again!");

                    callback = 0;
                }
            }
        }
    }
}
