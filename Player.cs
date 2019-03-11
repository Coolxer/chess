using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Player
    {
        private ConsoleColor color;

        public  Figure[] figures { get; set; }
        private char[] letters;

        public Player(char p)
        {
            letters = new char[8] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            figures = new Figure[16];

            if (p == 'w') // "white" -> red
            {
                color = ConsoleColor.Red;

                figures[0] = new Rook(new Point("a8"));
                figures[1] = new Knight(new Point("b8"));
                figures[2] = new Bishop(new Point("c8"));
                figures[3] = new Queen(new Point("d8"));
                figures[4] = new King(new Point("e8"));
                figures[5] = new Bishop(new Point("f8"));
                figures[6] = new Knight(new Point("g8"));
                figures[7] = new Rook(new Point("h8"));

                for (int i = 8, j = 0; i < 16; i++, j++)
                    figures[i] = new Pawn(new Point(letters[j].ToString() + '7'));
            }
            else if (p == 'b') // "black" -> blue
            {
                color = ConsoleColor.Blue;

                figures[0] = new Rook(new Point("a1"));
                figures[1] = new Knight(new Point("b1"));
                figures[2] = new Bishop(new Point("c1"));
                figures[3] = new Queen(new Point("d1"));
                figures[4] = new King(new Point("e1"));
                figures[5] = new Bishop(new Point("f1"));
                figures[6] = new Knight(new Point("g1"));
                figures[7] = new Rook(new Point("h1"));

                for (int i = 8, j = 0; i < 16; i++, j++)
                    figures[i] = new Pawn(new Point(letters[j].ToString() + '2'));
            }
        }

        public void move()
        {

        }
    }
}
