using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class AI : Player
    {
        public Point fp { get; set; }
        public Point mp { get; set; }
        public String cm { get; set; }

        private Board bo;
        private Player b;

        List<Figure> availables;

        private Point lastPos;

        public AI(char c, ref Board bo) : base(c)
        {
            availables = new List<Figure>();
            this.bo = bo;
        }

        private void generate()
        {
            foreach (Figure f in figures)
                f.generateAllowedMoves();

            for (int z = 0; z < figures.Count; z++)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (figures[z].matrix[i, j])
                        {
                            availables.Add(figures[z]);
                            i = j = 8;
                            break;
                        }
                    }
                }
            }
        }

        public String randomize()
        {
            Random random = new Random();

            //randomize the figure for which will be generated possible moves
            int fg = random.Next(0, availables.Count - 1);

            List<Point> poses = new List<Point>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (availables[fg].matrix[i, j])
                        poses.Add(new Point(i, j));
                }
            }

            int ng = random.Next(0, poses.Count - 1);

            fp = availables[fg].pos;
            mp = poses[ng];

            cm = fp.x.ToString() + fp.y.ToString() + mp.x.ToString() + mp.y.ToString();

            return cm;
        }

        public String evaluation()
        {
            int max = 0;
            Point pos = new Point();
            Point mv = new Point();
            //Figure _f = new Figure('b') ;

            foreach (Figure fig in availables)
            {
                for(int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < 8; j++)
                    {
                        if(fig.matrix[i,j])
                        {
                            for(int z = 0; z < b.figures.Count; z++)
                            {
                                Point p = new Point(i, j);

                                if (b.figures[z].pos != p)
                                    continue;

                                if(b.figures[z].value > max)
                                {
                                    max = b.figures[z].value;
                                    pos = p;
                                    mv = b.figures[z].pos;
                                    //_f = fig;
                                }
                            }
                        }
                    }
                }
            }

            if (max == 0)
                randomize();

            String s = pos.x.ToString() + pos.y.ToString() + mv.x.ToString() + mv.y.ToString();

            return s;
        }

        private int calcValue()
        {
            int value = 0;

            generate();

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(bo.fields[i, j] != null)
                    {
                        if (bo.fields[i, j].color == 'b')
                            value += bo.fields[i, j].value;
                        else
                            value -= bo.fields[i, j].value;
                    }
                }
            }

            return value;
        }

        public String chooseBestMove()
        {
            int moveValue;
            int bestValue = Int32.MinValue;

            String bestMove = "";

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (bo.fields[i, j] != null)
                    {
                        Figure f = bo.fields[i, j];

                        f.generateAllowedMoves();

                        for (int x = 0; x < 8; x++)
                        {
                            for (int y = 0; y < 8; y++)
                            {
                                if (f.matrix[x, y])
                                {
                                    Point m = new Point(x, y);

                                    lastPos = bo.fields[i, j].pos;
                                    f.move(m);
                                    moveValue = calcValue();

                                    if(moveValue > bestValue)
                                    {
                                        bestMove = lastPos.x.ToString() + lastPos.y.ToString() + m.x.ToString() + m.y.ToString();
                                        bestValue = moveValue;
                                    }

                                    f.move(lastPos);
                                }
                            }
                        }
                    }     
                }
            }

            return bestMove;
                            
        }

        public void minimax()
        {
            int depth = 3;

            int v;

            if (depth == 0)
                v = calcValue();



        }


    }
}
