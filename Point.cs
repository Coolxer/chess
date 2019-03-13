using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class Point
    {
        public int x { get; set; }
        public char y { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Point(String s)
        {
            y = s[0];
            x = X = Math.Abs((int)(char.GetNumericValue(s[1])) - 8);

            Y = (int)s[0] - 97;
        }

        //public Point(int x, int y)
        //{
        //    Y = y;
        //    X = this.x = Math.Abs(x - 8) ;

        //    y = Convert.ToChar(Y + 97);
        //}
    }
}
