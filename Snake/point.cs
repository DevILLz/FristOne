using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class point
    {
        static Random rng = new Random();
        public int x;
        public int y;
        static char Sym()
        {
            char Sym = '*';
            switch (rng.Next(1, 5))
            {
                case 1: Sym = '*'; break;
                case 2: Sym = '#'; break;
                case 3: Sym = '@'; break;
                case 4: Sym = '%'; break;
                case 5: Sym = '$'; break;
            }
            return Sym;
        }
        public char sym = Sym();
        public point()
        {

        }
        public point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }
        public void Draw()
        {
            if  (x==0 | y == 0)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.Write(sym);
            }
        }
        public point(point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
                x += offset;
            else if (direction == Direction.LEFT)
                x -= offset;
            else if (direction == Direction.UP)
                y -= offset;
            else if (direction == Direction.DOWN)
                y += offset;
        }
        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        public void Draw(int x, int y, char sym)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        public bool IsHit(point item)
        {
            return item.x == this.x && item.y == this.y;
        }

    }
}
