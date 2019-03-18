using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class Player
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

                figures[0] = new Rook(new Point("a1"), 'w', 0);
                figures[1] = new Knight(new Point("b1"), 'w', 1);
                figures[2] = new Bishop(new Point("c1"), 'w', 2);
                figures[3] = new Queen(new Point("d1"), 'w', 3);
                figures[4] = new King(new Point("e1"), 'w', 4);
                figures[5] = new Bishop(new Point("f1"), 'w', 5);
                figures[6] = new Knight(new Point("g1"), 'w', 6);
                figures[7] = new Rook(new Point("h1"), 'w', 7);

                for (int i = 8, j = 0; i < 16; i++, j++)
                    figures[i] = new Pawn(new Point(letters[j].ToString() + '2'), 'w', i);  
            }
            else if (p == 'b') // "black" -> blue
            {
                color = ConsoleColor.Blue;

                figures[0] = new Rook(new Point("a8"), 'b', 0);
                figures[1] = new Knight(new Point("b8"), 'b', 1);
                figures[2] = new Bishop(new Point("c8"), 'b', 2);
                figures[3] = new Queen(new Point("d8"), 'b', 3);
                figures[4] = new King(new Point("e8"), 'b', 4);
                figures[5] = new Bishop(new Point("f8"), 'b', 5);
                figures[6] = new Knight(new Point("g8"), 'b', 6);
                figures[7] = new Rook(new Point("h8"), 'b', 7);

                for (int i = 8, j = 0; i < 16; i++, j++)
                    figures[i] = new Pawn(new Point(letters[j].ToString() + '7'), 'b', i);
            }
        }

        public void move(string order)
        {
            Point p = new Point(order[0].ToString() + order[1].ToString());
            Point target = new Point(order[2].ToString() + order[3].ToString());

            //first there should be question if chosen position is free of OWN figures (can hit and kill opposite == GOOD)

            //if free we are looking what figure we want to move
            //for(int i = 0; i < figures.Length; i++)
            //{
            //    if (figures[i].pos == p)
            //        picked = figures[i];
            //}

            //there we should check in if the move is possible( the restrictions of the figure movement -> king, pawn, rook etc.)

            //if the move is possible we can change the figure position figure.pos = target; and get back to the game loop to regenerate board and draw it
        }

    }
}
