using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class AI
    {
        private Random random;
        private List<String> availablesMoves;

        private Point lastPos;

        private int value = 0;
        private bool own = true;

        public String bestMove { get; set; }

        public AI(char c)
        {
            availablesMoves = new List<String>();

            random = new Random();
        }

        /*
        private void generate()
        {
            if (availablesMoves.Count > 0)
                availablesMoves.Clear();

            foreach (Figure f in figures)
            {
                f.generateAllowedMoves();

                if(f.moves.Count > 0)
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

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Figure f = board.fields[i, j];

                    if(f != null)
                    {
                        if (f.color == 'w')
                            var += f.value;
                        else
                            var -= f.value;
                    }
                }
            }

            return var;
        }

        public String calcBestMoveOne()
        {
            generate();

            String best = "";
            int bestMoveValue = Int32.MinValue;

            foreach(String s in availablesMoves)
            {
                lastPos = new Point(s[0], s[1]);

                Figure f = board.fields[lastPos.X, lastPos.Y];

                f.move(new Point(s[2], s[3]));

                value = evaluateBoard();

                if(value > bestMoveValue)
                {
                    best = s;
                    bestMoveValue = value;
                }

                f.move(lastPos);
            }

            return best;                  
        }

        public int calcAB(int depth, bool own)
        {
            if(depth == 0)
                return evaluateBoard();

            int bestMoveValue = Int32.MinValue;

            generate();   

            foreach( String s in availablesMoves)
            {
                lastPos = new Point(s[0], s[1]);

                Figure f = board.fields[lastPos.X, lastPos.Y];

                f.move(new Point(s[2], s[3]));

                value = calcAB(depth - 1, !own);

                if(own)
                {
                    if(value > bestMoveValue)
                    {
                        bestMove = s;
                        bestMoveValue = value;
                    }
                }
                else
                {
                    if(value < bestMoveValue)
                    {
                        bestMove = s;
                        bestMoveValue = value;
                    }
                }

                f.move(lastPos);
            }

            return value;
        }

        public int calcBestMove(int depth, int alpha, int beta, bool own)
        {
            if (depth == 0)
                return evaluateBoard();

            generate();

            int bestMoveValue;

            if (own)
                bestMoveValue = Int32.MinValue;
            else
                bestMoveValue = Int32.MaxValue;

            foreach(String s in availablesMoves)
            {
                lastPos = new Point(s[0], s[1]);

                Figure f = board.fields[lastPos.X, lastPos.Y];

                f.move(new Point(s[2], s[3]));

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

                f.move(lastPos);

                if (beta <= alpha)
                    break;
            }

            return value;
        }
        */
    }
}
