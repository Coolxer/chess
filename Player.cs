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
    }
}
