using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            int delayInMillisecs = 50;

            int score = 0;

            //drawing a game field frame
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point snakeTail = new Point(15, 15, 's');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();

            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '$');
            Point food = foodGenerator.GenerateFood();
            food.Draw();

            FoodGenerator badFoodGenerator = new FoodGenerator(80, 25, '@');
            Point badFood = badFoodGenerator.GenerateBadFood();
            badFood.Draw();

            FoodGenerator freezeFoodGenerator = new FoodGenerator(80, 25, '!');
            Point freezeFood = freezeFoodGenerator.GenerateFreezeFood();
            freezeFood.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    Console.ForegroundColor = ConsoleColor.Green;
                    food.Draw();
                    score++;
                }
                if (snake.Eat(badFood))
                {
                    badFood = badFoodGenerator.GenerateBadFood();
                    Console.ForegroundColor = ConsoleColor.Red;
                    badFood.Draw();
                    score--;
                }
                if (snake.Eat(freezeFood))
                {
                    freezeFood = freezeFoodGenerator.GenerateFreezeFood();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    freezeFood.Draw();
                    Thread.Sleep(2500);
                }
                else
                {
                    snake.Move();
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }

                Thread.Sleep(100);
                Thread.Sleep(delayInMillisecs);
            }

            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
        }

        public static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("=========================", xOffset, yOffset++);
            WriteText("        GAME OVER        ", xOffset+1, yOffset++);
            yOffset++;
            WriteText($" You scored {score} points.", xOffset + 2, yOffset++);
            WriteText("", xOffset+1, yOffset++);
            WriteText("=========================", xOffset, yOffset++);
        }

        public static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        
    }
}
