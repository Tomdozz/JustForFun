using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Global
{
    class Fixed
    {
        public static int cellSize = 10;
        //public static int windowHeight = 720;
        //public static int windowWidth = 1280;

        public static int windowHeight = 1500;//820
        public static int windowWidth = 1500;//880

        public static Rectangle spawnBox()
        {
           return new Rectangle(windowHeight / 4, windowWidth / 4, 100, 100);
        }

        public static int spawnBoxX;
        public static int spawnBoxY;
        public static int ImResolution = 10;

        public static int maxX = 150;
        public static int maxY = 150;

        Random rnd;

        /// <summary>
        /// Random value, will return a float
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public float GetRandomNumber(float minimum, float maximum)
        {
            return (float)(rnd.NextDouble() * (maximum - minimum) + minimum);
        }
    }
}
