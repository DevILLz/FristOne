using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure
    {
        protected List<point> ll;
        public virtual void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (point p in ll)
                p.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
