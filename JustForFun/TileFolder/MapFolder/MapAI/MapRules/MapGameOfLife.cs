using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.TileFolder.MapFolder.MapAI.MapRules
{
    class MapGameOfLife : RuleSetMap
    {
        public MapGameOfLife(int[,] mapLayout, int maxX, int maxY)
            : base(mapLayout, maxX, maxY)
        {
            this.mapLayout = mapLayout;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        //Rules for map 
        protected override int[,] TickAlgorithm()
        {
            int[,] mapLayout2 = new int[maxX, maxY];

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (mapLayout[x, y] != 1)
                    {
                        List<Neighbor> neighborsList = GetNeighbors(x, y);

                        for (int i = 0; i < neighborsList.Count(); i++)
                        {
                            if (neighborsList[i].location == "left" || neighborsList[i].location == "up")
                            {
                                mapLayout2[x, y] = 1;
                                continue;
                            }
                        }
                    }

                    continue;

                    mapLayout2[x, y] = 0;
                }
            }
            return mapLayout2;
        }
    }
}
