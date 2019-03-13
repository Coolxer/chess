using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Bishop : Figure
    {
        public Bishop(Point p, char c) : base(p, c)
        {
            value = 'B';
        }

        public override void move()
        {

        }

        public override void allowMoves()
        {

        }
    }
}
