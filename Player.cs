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
        private Figure picked;

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

        public void move(string order)
        {
            Point p = new Point(order[0], order[1]);
            Point target = new Point(order[2], order[3]);

            //first there should be question if chosen position is free of OWN figures (can hit and kill opposite == GOOD)

            //if free we are looking what figure we want to move
            for(int i = 0; i < figures.Length; i++)
            {
                if (figures[i].pos == p)
                    picked = figures[i];
            }

            //there we should check in if the move is possible( the restrictions of the figure movement -> king, pawn, rook etc.)

            //if the move is possible we can change the figure position figure.pos = target; and get back to the game loop to regenerate board and draw it
        }
    }
}
