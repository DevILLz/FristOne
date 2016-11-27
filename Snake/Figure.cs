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
        public void Draw()
        {
            foreach (point p in ll)
                p.Draw(p.x, p.y);
        }
    }
}
