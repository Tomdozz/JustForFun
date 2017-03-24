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
        RuleSetMap mapRuleSet;

        public List<Wall> walls = new List<Wall>();

        Tile[,] tileGrid = new Tile[Fixed.maxX, Fixed.maxY];
        private static int[,] mapLayout = new int[Fixed.maxX, Fixed.maxY];

        Random rnd = new Random();
        Random rndX = new Random();
        Random rndY = new Random();

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

        public void Initi()
        {
            mapLayout[1, 2] = 1;
            mapLayout[2, 1] = 1;
            mapLayout[1, 1] = 1;

            mapLayout[10, 10] = 1;
            mapLayout[10, 11] = 1;
           //mapLayout[17, 10] = 1;
           //mapLayout[18, 10] = 1;
        }

        public void UpdateMap()
        {
            // for (int y = 0; y < Fixed.maxY; y++)
            // {
            //     for (int x = 0; x < Fixed.maxX; x++)
            //     {
            //         mapLayout[x, y] = rnd.Next(0, 1 + 1);
            //     }
            // }
            // mapLayout[4, 4] = 1;
            // mapLayout[4, 5] = 1;
            // mapLayout[5, 4] = 1;
            float mapLenght = Fixed.windowWidth * Fixed.windowWidth;
            if (mapLayout.Length < mapLenght / 4)
            {
                int x, y;
                x = rndX.Next(0, Fixed.windowWidth-1);
                y = rndY.Next(0, Fixed.windowHeight-1);

                mapLayout[x, y] = 1;
            }
            ruleSet = new TomsGameOfLife(mapLayout, Fixed.maxX, Fixed.maxY);


            //mapRuleSet = new MapGameOfLife(mapLayout, Fixed.maxX, Fixed.maxY);
            //for (int i = 0; i < 5000; i++)
            //{

            MakeMap();
            ruleSet.Tick();

            //mapLayout = ruleSet.NewFeild();
            //mapRuleSet.Tick();
            //}
        }

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
            //for (int i = 0; i < Fixed.windowWidth; i++)
            //{
            //    for (int j= 0; j < Fixed.windowHeight; j++)
            //    {
            //        tileGrid[i, j] = new Tile(new Vector2(i * 10, j * 10), TextureMananger.cell);
            //    }
            //
            //}
        }

        public void Draw(SpriteBatch sb)
        {
            // for (int x = 0; x < Fixed.windowWidth; x++)
            // {
            //     for (int y = 0; y < Fixed.windowHeight; y++)
            //     {
            //         tileGrid[x, y].Draw(sb);
            //     }
            // }

            foreach (Wall w in walls)
            {
                w.Draw(sb);
            }
            walls.Clear();


        }
    }
}
