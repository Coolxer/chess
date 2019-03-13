using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Queen : Figure
    {
        public Queen(Point p, char c) : base(p, c)
        {
            value = 'Q';
        }

        public override void move()
        {

        }

        public override void allowMoves()
        {

        }
    }
}
