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
        int stop;

        public List<Wall> walls = new List<Wall>();

        Tile[,] tileGrid = new Tile[Fixed.maxX, Fixed.maxY];
        private static int[,] mapLayout = new int[Fixed.maxX, Fixed.maxY];

        Random rnd = new Random();
        Random rndX = new Random();
        Random rndY = new Random();
        Random rndTime = new Random();
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
            mapLayout[11, 10] = 1;

            MakeEdges();

            //stop on random time between 0 and five seconds(seed is creaded)
            stop = rndTime.Next(3, 10);
        }

        public void UpdateMap(GameTime gameTime)
        {
            //choose ruleset
            if (gameTime.TotalGameTime.TotalSeconds < stop)
            {
                ruleSet = new TomsGameOfLife(mapLayout, Fixed.maxX, Fixed.maxY);

                MakeMap();
                ruleSet.Tick();

            }
            if (gameTime.TotalGameTime.TotalSeconds>stop)
            {
                MakeMap();
               // MakeEdges();
                //MakeMap();
            }
           

        }

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
