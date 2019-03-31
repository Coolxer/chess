using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class Player
    {

        private char[] letters;
        private Board board;

        private bool changed = false;

        public char color { get; set; }

        public  List <Figure> figures { get; set; }

        public int movements { get; set; }

        /* ----------------------------------------- */

        private List<String> availablesMoves;

        private Point lastPos;
        private Figure lastFigure;

        private int value = 0;
        private bool own = true;

        public String bestMove { get; set; }

        private Random random;

        public Player(char c, ref Board board)
        {
            color = c;
            letters = new char[8] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            figures = new List<Figure>();

            this.board = board;

            movements = 0;

            if (c == 'w')
            {
                figures.Add(new Rook(ref board, new Point("a1"), 'w', 0));
                figures.Add(new Knight(ref board, new Point("b1"), 'w', 1));
                figures.Add(new Bishop(ref board, new Point("c1"), 'w', 2));
                figures.Add(new Queen(ref board, new Point("d1"), 'w', 3));
                figures.Add(new King(ref board, new Point("e1"), 'w', 4));
                figures.Add(new Bishop(ref board, new Point("f1"), 'w', 5));
                figures.Add(new Knight(ref board, new Point("g1"), 'w', 6));
                figures.Add(new Rook(ref board, new Point("h1"), 'w', 7));

                for (int i = 8, j = 0; i < 16; i++, j++)
                    figures.Add(new Pawn(ref board, new Point(letters[j].ToString() + '2'), 'w', i));  
            }
            else if (c == 'b')
            {
                figures.Add(new Rook(ref board, new Point("a8"), 'b', 0));
                figures.Add(new Knight(ref board, new Point("b8"), 'b', 1));
                figures.Add(new Bishop(ref board, new Point("c8"), 'b', 2));
                figures.Add(new Queen(ref board, new Point("d8"), 'b', 3));
                figures.Add(new King(ref board, new Point("e8"), 'b', 4));
                figures.Add(new Bishop(ref board, new Point("f8"), 'b', 5));
                figures.Add(new Knight(ref board, new Point("g8"), 'b', 6));
                figures.Add(new Rook(ref board, new Point("h8"), 'b', 7));

                for (int i = 8, j = 0; i < 16; i++, j++)
                    figures.Add(new Pawn(ref board, new Point(letters[j].ToString() + '7'), 'b', i));

                availablesMoves = new List<String>();

                random = new Random();
            }
        }

        /**********************************************************************/

        private void generate()
        {
            if (availablesMoves.Count > 0)
                availablesMoves.Clear();

            foreach (Figure f in figures)
            {
                f.generateAllowedMoves();

                if (f.moves.Count > 0)
                {
                    foreach (String s in f.moves)
                        availablesMoves.Add(s);
                }
            }

            shuffle();
        }

        private void shuffle()
        {
            int n = availablesMoves.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);

                String value = availablesMoves[k];
                availablesMoves[k] = availablesMoves[n];
                availablesMoves[n] = value;
            }
        }

        public String randomize()
        {
            generate();

            int k = random.Next(0, availablesMoves.Count);

            return availablesMoves[k];
        }

        private int evaluateBoard()
        {
            int var = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Figure f = board.fields[i, j];

                    if (f != null)
                        var += f.value;
                }
            }

            return var;
        }

        public String calcBestMoveOne()
        {
            generate();

            int bestMoveValue = Int32.MinValue;

            foreach (String s in availablesMoves)
            {
                lastPos = new Point(s[0], s[1]);

                Figure f = board.fields[lastPos.X, lastPos.Y];

                Point p = new Point(s[2], s[3]);

                if(board.fields[p.X, p.Y] != null && board.fields[p.X, p.Y].color != color)
                {
                    lastFigure = board.fields[p.X, p.Y];
                    board.fields[p.X, p.Y] = f;

                    board.fields[lastPos.X, lastPos.Y] = null;

                    changed = true;
                }

                value = -evaluateBoard();

                if (value > bestMoveValue)
                {
                    bestMove = s;
                    bestMoveValue = value;
                }

                if(changed)
                {
                    board.fields[p.X, p.Y] = lastFigure;
                    board.fields[lastPos.X, lastPos.Y] = f;

                    changed = false;
                }
            }

            return bestMove;
        }

        public int calcAB(int depth)
        {
            if (depth == 0)
                return -evaluateBoard();

            int bestMoveValue = Int32.MinValue;

            generate();

            foreach (String s in availablesMoves)
            {
                lastPos = new Point(s[0], s[1]);

                Figure f = board.fields[lastPos.X, lastPos.Y];

                Point p = new Point(s[2], s[3]);

                if (board.fields[p.X, p.Y] != null && board.fields[p.X, p.Y].color != color)
                {
                    lastFigure = board.fields[p.X, p.Y];
                    board.fields[p.X, p.Y] = f;

                    board.fields[lastPos.X, lastPos.Y] = null;

                    changed = true;
                }


                value = calcAB(depth - 1);

                own = !own;

                if (own)
                {
                    if (value > bestMoveValue)
                    {
                        bestMove = s;
                        bestMoveValue = value;
                    }
                }
                else
                {
                    if (value < bestMoveValue)
                    {
                        bestMove = s;
                        bestMoveValue = value;
                    }
                }
            }

            return value;
        }

        public int calcBestMove(int depth, int alpha, int beta, bool own)
        {
            if (depth == 0)
                return -evaluateBoard();

            generate();

            int bestMoveValue;

            if (own)
                bestMoveValue = Int32.MinValue;
            else
                bestMoveValue = Int32.MaxValue;

            foreach (String s in availablesMoves)
            {
                lastPos = new Point(s[0], s[1]);

                Figure f = board.fields[lastPos.X, lastPos.Y];

                Point p = new Point(s[2], s[3]);

                if (board.fields[p.X, p.Y] != null && board.fields[p.X, p.Y].color != color)
                {
                    lastFigure = board.fields[p.X, p.Y];
                    board.fields[p.X, p.Y] = f;

                    board.fields[lastPos.X, lastPos.Y] = null;

                    changed = true;
                }

                value = calcBestMove(depth - 1, alpha, beta, !own);

                if (own)
                {
                    if (value > bestMoveValue)
                    {
                        bestMove = s;
                        bestMoveValue = value;
                    }
                }
                else
                {
                    if (value < bestMoveValue)
                    {
                        bestMove = s;
                        bestMoveValue = value;
                    }

                    beta = Math.Min(beta, value);
                }

                if (beta <= alpha)
                    break;
            }

            return value;
        }
    }
}
