using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Arena : Figure
    {
         int xleft, xright, ytop, ybuttom;
        public Arena(int xmax, int ymax)
        {
            Console.SetCursorPosition(25, 5);
            this.xleft = 25;
            this.xright = 25+xmax;
            this.ytop = 5;
            this.ybuttom = 5+ymax;
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
            Draw();
        }
        public bool IsHit(Snake snake)
        {
            return snake.ll[snake.ll.Count-1].x == xleft || snake.ll[snake.ll.Count - 1].y == ytop-1 || snake.ll[snake.ll.Count - 1].x == xright+1 || snake.ll[snake.ll.Count - 1].y == ybuttom;
        }

    }
}