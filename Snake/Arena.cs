using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Arena : Figure
    {
        public Arena(int xleft, int xright, int ytop, int ybuttom)
        {
            ll = new List<point>();
            for (int y = ytop; y < ybuttom; y++)
            {
                point p = new point(xleft, y, '0');
                ll.Add(p);
            }
            for (int y = ytop; y < ybuttom; y++)
            {
                point p = new point(xright + 1, y, '0');
                ll.Add(p);
            }


            for (int x = xleft; x < xright + 2; x++)
            {
                point p = new point(x, ytop - 1, '0');
                ll.Add(p);
            }
            for (int x = xleft; x < xright + 2; x++)
            {
                point p = new point(x, ybuttom, '0');
                ll.Add(p);
            }
        }
    }
}