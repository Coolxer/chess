using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class Point
    {
        //public char x { get; set; }
        //public char y { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Point(String s)
        {
            s.ToLower();

            X = (int)((char.GetNumericValue(s[1])) - 8) * -1;
            Y = s[0] - 97;
        }

        //public Point(int x, int y)
        //{
        //    Y = y;
        //    X = this.x = Math.Abs(x - 8) ;

        //    y = Convert.ToChar(Y + 97);
        //}
    }
}
