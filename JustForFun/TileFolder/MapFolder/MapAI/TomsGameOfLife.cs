using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.TileFolder.MapFolder.MapAI
{
    class TomsGameOfLife : RuleSet
    {
        public TomsGameOfLife(int[,] mapLayout, int maxX, int maxY)
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
                    //if(mapLayout[x,y] == 1)
                    //{
                    //    //mapLayout2[x, y] = mapLayout[x, y];
                    //    continue;
                    //}
                    if (mapLayout[x, y] != 1)
                    {

                        int neighbors = GetNeighbors(x, y);
                        //what is requierd to give birh
                        if (neighbors == 2)
                        {
                            mapLayout2[x, y] = 1;
                            continue;
                        }

                        //what is  rewuierd to survive
                        if (neighbors == 3 || neighbors == 1)
                        {
                            mapLayout2[x, y] = mapLayout[x, y];
                            continue;
                        }

                        mapLayout2[x, y] = 0;
                    }
                }
            }
            return mapLayout2;
            //throw new NotImplementedException();
        }
    }
}
