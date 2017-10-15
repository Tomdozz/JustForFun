using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using JustForFun.Global;
using JustForFun.TileFolder.MapFolder.MapAI;
using JustForFun.TileFolder.MapFolder.MapAI.MapRules;

namespace JustForFun.TileFolder.MapFolder
{
    public class Map
    {
        RuleSet ruleSet;
        RuleSet ruleSet2;
        RuleSetMap mapRuleSet;

        CaMakeMap caMakeMap;
        int stop;

        public List<Wall> walls = new List<Wall>();

        Tile[,] tileGrid = new Tile[Fixed.maxX, Fixed.maxY];
        private static int[,] mapLayout = new int[Fixed.maxX, Fixed.maxY];

        Random rnd = new Random();
        Random rndX = new Random();
        Random rndY = new Random();
        Random rndTimes = new Random();
        //Ladda från fil?
        //public static int[,] mapLayout = new int[,]
        //{
        //  { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //  { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        //};

        /// <summary>
        /// The width of the map.
        /// </summary>
        public int Width
        {
            get { return mapLayout.GetLength(1); }
        }
        /// <summary>
        /// The height of the map.
        /// </summary>
        public int Height
        {
            get { return mapLayout.GetLength(0); }
        }

        /// <summary>
        /// Initilize map with some seeds and a random number of itterations of (Toms way of life)
        /// </summary>
        public void Initi()
        {
            mapLayout[1, 2] = 1;
            mapLayout[2, 1] = 1;
            mapLayout[1, 1] = 1;
            mapLayout[0, 0] = 1;
            mapLayout[0, 1] = 1;
            mapLayout[0, 2] = 1;
            mapLayout[1, 0] = 1;
            mapLayout[0, 2] = 1;

            mapLayout[10, 10] = 1;
            mapLayout[10, 11] = 1;
            mapLayout[11, 10] = 1;

            MakeEdges();
            stop = rndTimes.Next(200, 500);
            for (int i = 0; i < stop; i++)
            {
                ruleSet = new TomsGameOfLife(mapLayout, Fixed.maxX, Fixed.maxY);

                MakeMap();
                ruleSet.Tick();
            }
            MakeEdges();
            MakeMap();

          // caMakeMap = new CaMakeMap(4, mapLayout, Fixed.maxX, Fixed.maxY);
          // int[,] newMap = caMakeMap.Run();
          //
          // for (int y = 0; y < Fixed.maxY; y++)
          // {
          //     for (int x = 0; x < Fixed.maxX; x++)
          //     {
          //         if (newMap[x, y] == 1)
          //         {
          //             Wall wall = new Wall(new Vector2(x * 10, y * 10), TextureMananger.cell);
          //             walls.Add(wall);
          //         }
          //     }
          // }

            //for (int i = 0; i < 300; i++)
            //{
            //ruleSet2 = new CaveGeneration(mapLayout, Fixed.maxX, Fixed.maxY);

            //ruleSet.Tick();
            //MakeMap();
            //}
        }

        /// <summary>
        /// All Parts of the map that has to be updated
        /// </summary>
        /// <param name="gameTime"></param>
        public void UpdateMap(GameTime gameTime)
        {
            //ruleSet2 = new CaveGeneration(mapLayout, Fixed.maxX, Fixed.maxY);
            //////  for (int i = 0; i < 300; i++)
            //////{
            //////for (int i = 0; i < 4; i++)
            //////{
            //MakeMap();
            //ruleSet2.Tick();
            //mapLayout = ruleSet2.NewFeild();
            //MakeMap();
            //}

        }

        /// <summary>
        /// Method to fill the map with edges
        /// </summary>
        public void MakeEdges()
        {
            for (int i = 0; i < Fixed.maxX; i++)
            {
                mapLayout[i, 0] = 1;
                mapLayout[i, 149] = 1;
            }
            for (int i = 0; i < Fixed.maxY; i++)
            {
                mapLayout[0, i] = 1;
                mapLayout[149, i] = 1;
            }
        }

        /// <summary>
        /// Based on int 2d array "map" is made by adding walls on the "ones"
        /// </summary>
        public void MakeMap()
        {
            for (int y = 0; y < Fixed.maxY; y++)
            {
                for (int x = 0; x < Fixed.maxX; x++)
                {
                    if (mapLayout[x, y] == 1)
                    {
                        Wall wall = new Wall(new Vector2(x * 10, y * 10), TextureMananger.cell);
                        walls.Add(wall);
                    }
                }
            }
        }

        /// <summary>
        /// Draw walls
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {

            foreach (Wall w in walls)
            {
                w.Draw(sb);
            }
            walls.Clear();


        }
    }
}
