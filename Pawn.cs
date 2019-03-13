using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Pawn : Figure
    {
        public Pawn(Point p, char c) : base(p, c)
        {
            value = 'P';
        }

        public override void move()
        {
            
        }

        public override void allowMoves()
        {
            
        }
    }
}
