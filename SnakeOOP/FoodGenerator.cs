using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeOOP
{
    class FoodGenerator
    {
        int mapWidth;
        int mapHeight;
        char symb;

        Random rnd = new Random();

        public FoodGenerator(int _mapWidth, int _mapHeight, char _symb)
        {
            mapWidth = _mapWidth;
            mapHeight = _mapHeight;
            symb = _symb;
        }

        public Point GenerateFood()
        {
            int x = rnd.Next(2, mapWidth - 2);
            int y = rnd.Next(2, mapHeight - 2);
            return new Point(x, y, symb);
        }

        public Point GenerateBadFood()
        {
            int x1 = rnd.Next(2, mapWidth - 2);
            int y1 = rnd.Next(2, mapHeight - 2);
            return new Point(x1, y1, symb);
        }

        public Point GenerateFreezeFood()
        {
            int x2 = rnd.Next(2, mapWidth - 2);
            int y2 = rnd.Next(2, mapHeight - 2);
            return new Point(x2, y2, symb);
        }

       
    }
}
