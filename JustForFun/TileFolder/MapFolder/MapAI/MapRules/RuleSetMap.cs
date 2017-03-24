using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.TileFolder.MapFolder.MapAI.MapRules
{
    public class Neighbor
    {
        public string location;

        public Neighbor(string location)
        {
            this.location = location;
        }
    }

    public abstract class RuleSetMap
    {
        protected int maxX;
        protected int maxY;

        protected int[,] mapLayout;

        public RuleSetMap(int[,] mapLayout, int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            this.mapLayout = mapLayout;
        }

        protected List<Neighbor> GetNeighbors(int x, int y)
        {
            List<Neighbor> neighborList = new List<Neighbor>();
            int neighbors = 0;

            //check right
            if (x + 1 < maxX && mapLayout[x + 1, y] == 1)
            {
                Neighbor neighbor = new Neighbor("right");
                neighborList.Add(neighbor);
                neighbors++;
            }
            //check left
            if (x - 1 >= 0 && mapLayout[x - 1, y] == 1)
            {
                Neighbor neighbor = new Neighbor("left");
                neighborList.Add(neighbor);
                neighbors++;
            }
            //check down
            if (y + 1 < maxY && mapLayout[x, y + 1] == 1)
            {
                Neighbor neighbor = new Neighbor("down");
                neighborList.Add(neighbor);
                neighbors++;
            }
            //ckeck up
            if (y - 1 >= 0 && mapLayout[x, y - 1] == 1)
            {
                Neighbor neighbor = new Neighbor("up");
                neighborList.Add(neighbor);
                neighbors++;
            }

            //check rightDown
            if (x + 1 < maxX && y + 1 < maxY && mapLayout[x + 1, y + 1] == 1)
            {
                Neighbor neighbor = new Neighbor("rightDown");
                neighborList.Add(neighbor);
                neighbors++;
            }
            //check rightUp
            if (x + 1 < maxX && y - 1 >= 0 && mapLayout[x + 1, y - 1] == 1)
            {
                Neighbor neighbor = new Neighbor("rightUp");
                neighborList.Add(neighbor);
                neighbors++;
            }
            //check leftDown
            if (x - 1 >= 0 && y + 1 < maxY && mapLayout[x - 1, y + 1] == 1)
            {
                Neighbor neighbor = new Neighbor("leftDown");
                neighborList.Add(neighbor);
                neighbors++;
            }
            //check leftUp
            if (x - 1 >= 0 && y - 1 >= 0 && mapLayout[x - 1, y - 1] == 1)
            {
                Neighbor neighbor = new Neighbor("leftDown");
                neighborList.Add(neighbor);
                neighbors++;
            }
            return neighborList;
        }

        public void Tick()
        {
            int[,] field2 = TickAlgorithm();
            Array.Copy(field2, mapLayout, field2.Length);

        }

        public int[,] ReturnMap()
        {
            return TickAlgorithm();
        }

        protected abstract int[,] TickAlgorithm();
    }
}
