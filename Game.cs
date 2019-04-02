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

        private int callback;

        public Game()
        {
            cmd = new Commander();
            board = new Board();

            reset();
        }

        private void reset()
        {
            board.reset();
            
            w = new Player('w', ref board);
            b = new Player('b', ref board);

            judge = new Judge(ref board, ref w, ref b);

            draw();
        }

        private void draw()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Current turn: " + judge.turn);

            board.createGrid(w.figures, b.figures);
        }

        public void run()
        {
            while (true)
            {
                if (judge.ai && judge.turn == 'b')
                {
                    b.calcBestMoveOne();

                    callback = judge.rating(b.bestMove);
                }   
                else
                {
                    String call = Console.ReadLine();
                    int code = cmd.process(call);

                    if (code == 0)
                        break;
                    else if (code == 1)
                        callback = judge.rating(call);
                    else if (code == 2)
                        reset();
                    else if (code == 3)
                        judge.ai = true;
                    else if (code == 4)
                    {
                        draw();
                        judge.showPossibleMoves(call);
                    }
                }
                
                if (callback == 1)
                {
                    draw();
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
