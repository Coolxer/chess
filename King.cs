﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class King : Figure
    {
        //castling
        public King(Point p, char c) : base(p, c)
        {
            value = 'K';
        }

        public override void generateAllowedMoves()
        {
            clearMatrix();

            if(pos.X > 0)
            {
                if(pos.Y > 0)
                    if (board.fields[pos.X - 1, pos.Y - 1] == null || board.fields[pos.X - 1, pos.Y - 1].color != color)
                        matrix[pos.X - 1, pos.Y - 1] = true;

                if (board.fields[pos.X - 1, pos.Y] == null || board.fields[pos.X - 1, pos.Y].color != color)
                    matrix[pos.X - 1, pos.Y] = true;
                
                if(pos.Y < 7)
                    if (board.fields[pos.X - 1, pos.Y + 1] == null || board.fields[pos.X - 1, pos.Y + 1].color != color)
                        matrix[pos.X - 1, pos.Y + 1] = true;
            }

            if(pos.Y > 0)
                if (board.fields[pos.X, pos.Y - 1] == null || board.fields[pos.X, pos.Y - 1].color != color)
                    matrix[pos.X, pos.Y - 1] = true;

            if (pos.Y < 7)
                if (board.fields[pos.X, pos.Y + 1] == null || board.fields[pos.X, pos.Y + 1].color != color)
                    matrix[pos.X, pos.Y + 1] = true;

            if(pos.X < 7)
            {
                if (pos.Y > 0)
                    if (board.fields[pos.X + 1, pos.Y - 1] == null || board.fields[pos.X + 1, pos.Y - 1].color != color)
                        matrix[pos.X + 1, pos.Y - 1] = true;

                if (board.fields[pos.X + 1, pos.Y] == null || board.fields[pos.X + 1, pos.Y].color != color)
                    matrix[pos.X + 1, pos.Y] = true;

                if (pos.Y < 7)
                    if (board.fields[pos.X + 1, pos.Y + 1] == null || board.fields[pos.X + 1, pos.Y + 1].color != color)
                        matrix[pos.X + 1, pos.Y + 1] = true;
            }

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (matrix[i, j])
                        Console.Write('1');
                    else
                        Console.Write('0');
                }

                Console.WriteLine();
            }
        }
    }
}
