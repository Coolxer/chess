using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class King : Figure
    {
        public King(Point p) : base(p)
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
