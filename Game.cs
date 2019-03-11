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

        bool turn = false; //white player turn

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

                string command = Console.ReadLine();

                if (command.Length != 0)
                {
                    if (command == "exit" || command == "quit")
                        break;
                    else
                    {
                        if(validMoveCommand(command))
                        {
                            Console.WriteLine("valid");
                            if (!turn)
                                w.move();
                            else
                                b.move();
                        }
                        else
                            Console.WriteLine("not valid");
                    }
                }  
            }
        }

        private bool validMoveCommand(string cmd)
        {
            bool valid = true;

            if (cmd.Length != 4 )
                valid = false;
            else
            {
                //if ((cmd[0] >= 97 && cmd[0] <= 104) && (cmd[1] >= 49 && cmd[1] <= 56) && (cmd[2] >= 97 && cmd[2] <= 104) && (cmd[3] >= 49 && cmd[3] <= 56))
                if ((cmd[0] < 97 || cmd[0] > 104) || (cmd[1] < 49 || cmd[1] > 56) || (cmd[2] < 97 || cmd[2] > 104) || (cmd[3] < 49 || cmd[3] > 56))
                    valid = false;
            }

            return valid;
        }
    }
}
