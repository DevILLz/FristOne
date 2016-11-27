using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake 
{
    class Food 
    {
        int xleft;
        int xright;
        int ytop;
        int ybuttom;

        public char sym = '$';
        Random rng = new Random();
        
        public Food(int xleft, int xright, int ytop, int ybuttom)
        {
            this.xright = xright;
            this.xleft = xleft;
            this.ytop = ytop;
            this.ybuttom = ybuttom;
        }
        public point CreateFood()
        {
            int x = rng.Next(xleft + 1, xright - 1);
            int y = rng.Next(ytop + 1, ybuttom - 1);
            return new point(x,y,sym);
        }
        public void Draw()
        {
            Console.Write(sym);
        }
    }
}
