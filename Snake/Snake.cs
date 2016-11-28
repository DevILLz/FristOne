using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public List<point> ll;
        public int lenght;
        private Direction direction;
        public Snake(point tail, int lenght, Direction _direction)
        {
            this.lenght = lenght;
            direction = _direction;
            ll = new List<point>();
            for (int i = 0; i <= lenght; i++)
            {
                point p = new point(tail.x, tail.y, tail.sym);
                p.Move(i, direction);
                ll.Add(p);
            }
        }
        internal bool eat(point food)
        {
            point head = GetNextPoint();
            if (head.IsHit(food))
            {
                ll.Insert(0, food);
                return true;
            }
            else return false;
        }

        public void choicedirection()
        {
            if (Console.KeyAvailable)
            {
                Direction last = direction;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (last == Direction.RIGHT) direction = Direction.RIGHT;
                    else direction = Direction.LEFT;
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (last == Direction.LEFT) direction = Direction.LEFT;
                    else direction = Direction.RIGHT;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (last == Direction.DOWN) direction = Direction.DOWN;
                    else direction = Direction.UP;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (last == Direction.UP) direction = Direction.UP;
                    else direction = Direction.DOWN;
                }
            }
        }

        internal void Move(int x)
        {
            point tail = ll.First();
            ll.Remove(tail);
            point head = GetNextPoint();
            ll.Add(head);
            tail.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            head.Draw();
            Console.ForegroundColor = ConsoleColor.White;
            if (direction == Direction.UP || direction == Direction.DOWN)
            {
                if (x == 20) Thread.Sleep(x + 20);
                else Thread.Sleep(x + 50);
            }
            else Thread.Sleep(x);
        }
        private point GetNextPoint()
        {
            point head = ll.Last();
            point NextPoint = new point(head);
            NextPoint.Move(1, direction);
            return NextPoint;
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (point p in ll)
                p.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public bool IsHitYouSelf()
        {
            point head = GetNextPoint();
            for (int i = ll.Count-1; i >0;i-- )
                if (head.IsHit(ll[i]))
                    {
                       return true;
                    }
            return false;
        }
    }
}
