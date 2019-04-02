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
        private Player w, b, c, nc;
        private Figure current = null;
        private Figure target = null;

        public bool ai { get; set; }
        public char turn { get; set; }

        public Judge(ref Board board, ref Player w, ref Player b)
        {
            this.board = board;
            this.w = w;
            this.b = b;

            c = w;
            nc = b;

            turn = c.color;

            ai = false; 
        }

        public void showPossibleMoves(String cmd)
        {
            Point p = new Point(cmd);

            current = board.fields[p.X, p.Y];

            if (current == null)
                return;

            if (current.color != c.color)
                return;

            current.generateAllowedMoves();

            Console.WriteLine();
            Console.WriteLine("possible movements: ");

            foreach (String s in current.moves)
                Console.Write(" " + s);

            current.showThruthTable();

            if (current.moves.Count == 0)
                Console.WriteLine("No possible moves for this figure");

            Console.WriteLine();        
        }

        public int rating(String request)
        {
            Point fp = new Point(request[0].ToString() + request[1].ToString());
            Point mp = new Point(request[2].ToString() + request[3].ToString());

            current = board.fields[fp.X, fp.Y];
            target = board.fields[mp.X, mp.Y];

            if (!ai || turn == 'w')
            {
                //if user chose no figure (empty field)
                if (current == null)
                    return 0;

                //if user chose no its own figure (opponent figure chosen)
                if (current.color != c.color)
                    return 0;

                //if user want to move its own figure above its own figure w to w, b to b
                if (target != null && target.color == current.color)
                    return 0;

                current.generateAllowedMoves();

                if (!current.matrix[mp.X, mp.Y])
                    return 0;
            }

            //removed hit figure
            if (target != null)
            {
                nc.figures.Remove(target);
                board.fields[mp.X, mp.Y] = null;
            }

            current.move(mp);
            board.fields[mp.X, mp.Y] = current;

            board.fields[fp.X, fp.Y] = null;

            c.movements++;

            if (checkForMate())
                return 2;

            int n = (c.color == 'w') ? 0 : 7;

            if (current.type == 'P' && current.pos.X == n)
            {
                int z = c.figures.IndexOf(current);
                c.figures[z] = new Queen(ref board, current.pos, c.color);
            }
            
            Player p = c;
            c = nc;
            nc = p;

            turn = c.color;

            System.Threading.Thread.Sleep(350);

            return 1;
        }

        private bool checkForMate()
        {
            if (nc.movements >= 2)
            {
                nc.king.generateAllowedMoves();

                if (nc.king.moves.Count == 0)
                {
                    foreach (Figure f in c.figures)
                    {
                        foreach (String move in f.moves)
                        {
                            if (move.Contains(nc.king.pos.coords()))
                                return true;
                        }
                    }
                }
                else
                {
                    foreach (Figure f in c.figures)
                    {
                        f.generateAllowedMoves();

                        foreach (String move in f.moves)
                        {
                            for (int i = 0; i < nc.king.moves.Count; i++)
                            {
                                String movement = nc.king.moves[i];

                                String s = String.Concat(movement[2], movement[3]);

                                if (move.Contains(s))
                                    nc.king.moves.Remove(movement);
                            }
                        }
                    }
                    if (nc.king.moves.Count == 0)
                        return true;
                }
                return false;
            }
            return false;
        }
    }
}
