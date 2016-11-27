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
            Console.SetCursorPosition(35, 0);
            Console.Write("Wlecome to mine \"Snake\" game \n");
            Console.SetCursorPosition(40, 1);
            Console.Write("For start, tap ENTER\n");
            Console.ReadKey();
            point p1 = new point();
            Arena arena = new Arena(25, 80, 4, 25);
            arena.Draw();

            point p = new point(26, 5, 'O');
            Snake snake = new Snake(p, 8, Direction.RIGHT);
            snake.Draw();

            Food FOOD = new Food(25, 80, 4, 25);
            point food = FOOD.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.eat(food))
                {
                    food = FOOD.CreateFood();
                    food.Draw();
                }
                

                snake.choicedirection(snake);               
                snake.Move(snake);
            }
        }        
	}
}
