using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.TileFolder.MapFolder.MapAI
{
    class ConwaysGameOfLife:RuleSet
    {
        public ConwaysGameOfLife(int[,] mapLayout, int maxX, int maxY)
            :base(mapLayout,maxX,maxY)
        {
        }

        protected override int[,] TickAlgorithm()
        {
            int[,] mapLayout2 = new int[maxX, maxY];
            
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    int neighbors = GetNeighbors(x, y);

                    //if (mapLayout[x, y] == 1)
                    //{
                    //    //mapLayout2[x, y] = 1;
                    //    continue;
                    //}

                    //3 is the cell reqierd amout to spawn a cell
                    if (neighbors == 3)
                    {
                        mapLayout2[x, y] = 1;
                        continue;
                    }

                    //2,3 i requierd for the the cell to live
                    if (neighbors == 2|| neighbors == 3)
                    {
                        mapLayout2[x,y] = mapLayout[x,y];
                        continue;
                    }

                    mapLayout2[x, y] = 0;
                }
            }
            return mapLayout2;
            //throw new NotImplementedException();
        }
    }
}
