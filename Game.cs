﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Game
    {
        Commander cmd;

        Board board;
        Player w;
        Player b;

        bool redraw = true;

        public Game()
        {
            cmd = new Commander();
            board = new Board();
            w = new Player('w');
            b = new Player('b');

            Judge.Instance.init(ref board, ref w, ref b);
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

                String call = Console.ReadLine();
                int code = cmd.process(call);

                if (code == 0)
                    break;
                else if(code == 1)
                {
                    if(Judge.Instance.consider(call))
                    {

                    }
                }
                    ;
            }
        }
    }
}
