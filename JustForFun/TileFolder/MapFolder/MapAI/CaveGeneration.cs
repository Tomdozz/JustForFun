using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.TileFolder.MapFolder.MapAI
{
    class CaveGeneration : RuleSet
    {
        public CaveGeneration(int[,] mapLayout, int maxX, int maxY)
            : base(mapLayout, maxX, maxY)
        {

        }
        protected override int[,] TickAlgorithm()
        {
            int[,] mapLayout2 = new int[maxX, maxY];

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (mapLayout[x, y] != 1)
                    {
                        int neighbors = GetNeighbors(x, y);

                        //Birth
                        if (neighbors == 6 || neighbors == 7 || neighbors == 8)
                        {
                            mapLayout2[x, y] = 1;
                            continue;
                        }

                        //survive
                        if (neighbors >= 3 && neighbors <= 8)
                        {
                            mapLayout2[x, y] = mapLayout[x, y];
                            continue;
                        }



                    }
                }
            }
            return mapLayout2;
        }
    }
}
