using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
	 class Program
	{
        static void Main(string[] args)
        {
            trash();
            Console.SetCursorPosition(40, 2);
            Console.Write("Speed:");
            int x = 40;
            while (true)
            {
                string st1 = Console.ReadLine();
                if (st1 == "") st1 = "50";
                x = Int32.Parse(st1);
                if (x == 20 || x == 50 || x == 100 || x == 200) break;
                else
                {
                    ClearThisString(46, 2);
                    Console.SetCursorPosition(46, 2);
                }
            }

            Console.SetCursorPosition(40, 3);
            Console.Write("Scale:");
            int scale = 15;
            while (true)
            {
                string st1 = Console.ReadLine();
                if (st1 == "") st1 = "35";
                scale = Int32.Parse(st1);
                if (scale == 20 || scale == 35 || scale == 50) break;
                else
                {
                    ClearThisString(46, 3);
                    Console.SetCursorPosition(46, 3);
                }
            }

            int xmax = 10, ymax = 6;
            if (scale == 20) {xmax = scale; ymax = scale - 10;}
            if (scale == 35) {xmax = scale; ymax = scale - 20;}
            if (scale == 50) {xmax = scale; ymax = scale - 30;}

            Arena arena = new Arena(xmax, ymax);
            point p = new point(26, 5, 'O');
            Snake snake = new Snake(p, 3, Direction.RIGHT);
            snake.Draw();

            Food FOOD = new Food(xmax, ymax);
            point food = FOOD.CreateFood(snake);
            Console.ForegroundColor = ConsoleColor.Yellow;
            food.Draw();

            while (true)
            {
                snake.choicedirection();
                if (snake.IsHitYouSelf()) break;
                if (arena.IsHit(snake)) break;

                if (snake.eat(food))
                {
                    food = FOOD.CreateFood(snake);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    food.Draw();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                snake.Move(x);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            if (scale == 50) Console.SetCursorPosition(46, 14);       
            if (scale == 35) Console.SetCursorPosition(39, 12);
            if (scale == 20) Console.SetCursorPosition(31, 9);
            Console.Write("GAME OVER");
            Console.ReadKey();
        }

        static void trash()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 0);
            Console.Write("Wlecome to mine \"Snake\" game \n");
            Console.SetCursorPosition(36, 1);
            Console.Write("For start, set wanted speed abd scale of the map \n");
            Console.SetCursorPosition(0, 0);
            Console.Write("Speed steps:");
            Console.SetCursorPosition(5, 1);
            Console.Write("20  - Super Fast");
            Console.SetCursorPosition(5, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("50  - Fast");
            Console.SetCursorPosition(5, 3);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("100 - Middle");
            Console.SetCursorPosition(5, 4);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("200 - Slow");
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Default - 50");
            
            Console.SetCursorPosition(0, 7);
            Console.Write("Scale steps:");
            Console.SetCursorPosition(5, 8);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("20 - Small");
            Console.SetCursorPosition(5, 9);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("35 - Normal");
            Console.SetCursorPosition(5, 10);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("50 - Big");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(5, 11);
            Console.Write("Default - 35");
        }
        static void ClearThisString(int x, int y)
        {
            for (int i = x; i< x + 20; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(" ");
            }
        }
	}
}
