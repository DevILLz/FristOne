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
        
        public Food(int xmax, int ymax)
        {
            this.xleft = 25;
            this.xright = 25 + xmax;
            this.ytop = 5;
            this.ybuttom = 5 + ymax;
        }
        public point CreateFood(Snake snake)
        {
            int x = rng.Next(xleft + 1, xright - 1);
            int y = rng.Next(ytop + 1, ybuttom - 1);
            for (int i = 0; i <= snake.ll.Count-1; i++)
                foreach (point p in snake.ll)
                {
                    while (p.x == x) x = rng.Next(xleft + 1, xright - 1);
                    while (p.y == y) y = rng.Next(ytop + 1, ybuttom - 1);
                }
            return new point(x,y,sym);
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(sym);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
