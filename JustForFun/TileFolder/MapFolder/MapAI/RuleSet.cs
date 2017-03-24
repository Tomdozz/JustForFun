using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.TileFolder.MapFolder.MapAI
{
    public abstract class RuleSet
    {
        protected int maxX;
        protected int maxY;

        protected int[,] mapLayout;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapLayout"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        public RuleSet(int[,] mapLayout, int maxX, int maxY)
        {
            this.mapLayout = mapLayout;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        /// <summary>
        /// Returns the number of neighbors
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected int GetNeighbors(int x, int y)
        {
            int neighbors = 0;

            if (x + 1 < maxX && mapLayout[x + 1, y] == 1)
            {
                neighbors++;
            }

            if (x - 1 >= 0 && mapLayout[x - 1, y] == 1)
            {
                neighbors++;
            }
            if (y + 1 < maxY && mapLayout[x, y + 1] == 1)
            {
                neighbors++;
            }
            if (y - 1 >= 0 && mapLayout[x, y - 1] == 1)
            {
                neighbors++;
            }

            if (x + 1 < maxX && y + 1 < maxY && mapLayout[x + 1, y + 1] == 1)
            {
                neighbors++;
            }
            if (x + 1 < maxX && y - 1 >= 0 && mapLayout[x + 1, y - 1] == 1)
            {
                neighbors++;
            }
            if (x - 1 >= 0 && y + 1 < maxY && mapLayout[x - 1, y + 1] == 1)
            {
                neighbors++;
            }
            if (x - 1 >= 0 && y - 1 >= 0 && mapLayout[x - 1, y - 1] == 1)
            {
                neighbors++;
            }
            return neighbors;
        }

        public int[,] NewFeild()
        {
            int[,] returnFeild = TickAlgorithm();
            return returnFeild;
        }

        public void Tick()
        {
            int[,] field2 = TickAlgorithm();
            Array.Copy(field2, mapLayout, field2.Length);
            //mapLayout = field2;
        }

        /// <summary>
        /// Can be overridded to impliment different rules
        /// </summary>
        /// <returns></returns>
        protected abstract int[,] TickAlgorithm();
    }
}
