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

        public AI(char c) : base(c) { }

        public void randomize()
        {
            List<Figure> availables = new List<Figure>();

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
                            //z++ ?
                            break;
                        }
                    }
                }
            }

            Random random = new Random();

            int fg = random.Next(0, availables.Count - 1);

            List<Point> poses = new List<Point>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(availables[fg].matrix[i,j])
                        poses.Add(new Point(i, j));
                }
            }

            int ng = random.Next(0, poses.Count - 1);

            fp = availables[fg].pos;
            mp = poses[ng];

            cm = fp.ToString() + mp.ToString();
        }
    }
}
