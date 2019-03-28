using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class Player
    {
        public char color { get; set; }

        public  List <Figure> figures { get; set; }
        private char[] letters;

        public int movements { get; set; }

        public Player(char c)
        {
            color = c;
            letters = new char[8] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            figures = new List<Figure>();

            movements = 0;

            if (c == 'w')
            {
                figures.Add(new Rook(new Point("a1"), 'w', 0));
                figures.Add(new Knight(new Point("b1"), 'w', 1));
                figures.Add(new Bishop(new Point("c1"), 'w', 2));
                figures.Add(new Queen(new Point("d1"), 'w', 3));
                figures.Add(new King(new Point("e1"), 'w', 4));
                figures.Add(new Bishop(new Point("f1"), 'w', 5));
                figures.Add(new Knight(new Point("g1"), 'w', 6));
                figures.Add(new Rook(new Point("h1"), 'w', 7));

                for (int i = 8, j = 0; i < 16; i++, j++)
                    figures.Add(new Pawn(new Point(letters[j].ToString() + '2'), 'w', i));  
            }
            else if (c == 'b')
            {
                figures.Add(new Rook(new Point("a8"), 'b', 0));
                figures.Add(new Knight(new Point("b8"), 'b', 1));
                figures.Add(new Bishop(new Point("c8"), 'b', 2));
                figures.Add(new Queen(new Point("d8"), 'b', 3));
                figures.Add(new King(new Point("e8"), 'b', 4));
                figures.Add(new Bishop(new Point("f8"), 'b', 5));
                figures.Add(new Knight(new Point("g8"), 'b', 6));
                figures.Add(new Rook(new Point("h8"), 'b', 7));

                for (int i = 8, j = 0; i < 16; i++, j++)
                    figures.Add(new Pawn(new Point(letters[j].ToString() + '7'), 'b', i));
            }
        }

        public Point fp { get; set; }
        public Point mp { get; set; }
        public String cm { get; set; }

        public String randomize()
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
    }
}
