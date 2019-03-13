using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Knight : Figure
    {
        public Knight(Point p, char c) : base(p, c)
        {
            value = 'K';
        }

        public override void move()
        {

        }

        public override void allowMoves()
        {

        }
    }
}
