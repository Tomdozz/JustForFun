using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.TileFolder.MapFolder.MapAI
{
    class CaMakeMap
    {
        int itteration;

        int maxX, maxY;
        protected int[,] mapLayout;
        public CaMakeMap(int itteration, int[,] mapLayout, int maxX, int maxY)
        {
            this.itteration = itteration;
            this.maxX = maxX;
            this.maxY = maxY;
            this.mapLayout = mapLayout;
        }

        public int[,] Run()
        {
            int[,] map = new int[maxX, maxY];
            for (int i = 0; i < itteration; i++)
            {
                map = CheckRules();
            }

            return map;
        }

        /// <summary>
        /// Get # of neighbors
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int GetNeighbors(int x, int y)
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

        /// <summary>
        /// CheckRules 
        /// </summary>
        /// <returns></returns>
        public int[,] CheckRules()
        {
            int[,] mapLayout2 = new int[maxX, maxY];

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {

                    if (mapLayout[x, y] != 1)
                    {
                        int neighbors = GetNeighbors(x, y);

                        //bith
                        if (neighbors >= 6)
                        {
                            mapLayout2[x, y] = 1;
                            continue;
                        }

                        //sirvive
                        if (neighbors >= 3)
                        {
                            mapLayout2[x, y] = mapLayout[x, y];
                            continue;
                        }
                        mapLayout2[x, y] = 0;
                    }
                }
            }
            return mapLayout2;
        }
    }
}

