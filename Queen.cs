using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Queen : Figure
    {
        public Queen(Point p) : base(p)
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
