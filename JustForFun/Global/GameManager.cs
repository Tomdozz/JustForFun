using JustForFun.FlockingFolder.BoidsFlocking;
using JustForFun.Steering;
using JustForFun.TileFolder.MapFolder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Global
{
    class GameManager
    {
        Map map;
        BoidController boidController;
        Enemy enemy;
        Enemy leader;
        SteeringController sController;

        public GameManager()
        {
            map = new Map();
            boidController = new BoidController(TextureMananger.tri);
            enemy = new Enemy(300f, 300f);
            leader = new Enemy(600f, 500f);
            leader.m_MaxSpeed = 2;
            sController = new SteeringController();
        }

        /// <summary>
        /// Initilize all stuffs
        /// </summary>
        public void Initi()
        {
            //map.Initi();
            //map.MakeMap();
        }

        /// <summary>
        /// Loads all stuffs
        /// </summary>
        public void Load()
        {

        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            //leader.Wander2(KeyMouseReader1.GetMousePosition(), gameTime);
            leader.Approach(KeyMouseReader1.GetMousePosition());
            //enemy.Approach(KeyMouseReader1.GetMousePosition());
            //enemy.Wander2(KeyMouseReader1.GetMousePosition(),gameTime);
            //sController.Update(gameTime);
            enemy.Pursuit(leader);
            //boidController.Update();
            //map.UpdateMap();
        }

        /// <summary>
        /// Draws the game
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            //map.Draw(sb);
            //sController.Draw(sb);
           sb.Draw(TextureMananger.tri, KeyMouseReader1.GetMousePosition(), Color.White);
           enemy.Draw(sb);
          //  boidController.Draw(sb);
            sb.End();
        }
    }
}
