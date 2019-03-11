using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Game
    {
        Board board;
        Player w;
        Player b;

        bool redraw = true;

        public Game()
        {
            board = new Board();
            w = new Player('w');
            b = new Player('b');
        }

        public void run()
        {
            while (true)
            {
                if (redraw)
                {
                    board.createGrid(w.figures, b.figures);
                    redraw = false;
                }

                string info = Console.ReadLine();

                if (info == "exit" || info == "quit")
                    break;
            }
        }
    }
}
