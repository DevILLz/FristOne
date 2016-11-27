using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        int lenght;
        private Direction direction;
        public Snake(point tail, int lenght, Direction _direction)
        {
            this.lenght = lenght;
            direction = _direction;
            ll = new List<point>();
            for (int i = 0; i < lenght; i++)
            { 
                point p = new point(26, 5, tail.sym);
                p.Move(i, direction);
                ll.Add(p);
            }
        }
        internal bool eat(point food)
        {
            point head = GetNextPoint();
            if (head.IsHit(food))
            {
                head.Draw(head.x, head.y, '0');
                food.sym = head.sym;
                ll.Add(food);
                lenght++;
                return true;
            }
            else return false;
        }

        public void choicedirection(Snake snake)
        {
            if (Console.KeyAvailable)
            {
                Direction last = snake.direction;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (last == Direction.RIGHT) snake.direction = Direction.RIGHT;
                    else snake.direction = Direction.LEFT;
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (last == Direction.LEFT) snake.direction = Direction.LEFT;
                    else snake.direction = Direction.RIGHT;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (last == Direction.DOWN) snake.direction = Direction.DOWN;
                    else snake.direction = Direction.UP;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (last == Direction.UP) snake.direction = Direction.UP;
                    else snake.direction = Direction.DOWN;
                }
            }
        }

        internal void Move(Snake snake)
        {
            point tail = ll.First();
            ll.Remove(tail);
            point head = GetNextPoint();
            ll.Add(head);
            tail.Clear();
            head.Draw();
            if(snake.direction == Direction.UP | snake.direction == Direction.DOWN) Thread.Sleep(150);
            else Thread.Sleep(100);
        }
        private point GetNextPoint()
        {
            point head = ll.Last();
            point NextPoint = new point(head);
            NextPoint.Move(1, direction);
            return NextPoint;
        }
    }
}
