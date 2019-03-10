using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Pawn : Figure
    {
        public Pawn(Player player, Point p)
        {
            value = 'P';
            color = player.color;

            pos = p;
        }

        public override void move()
        {
            
        }

        public override void allowMoves()
        {
            
        }
    }
}
