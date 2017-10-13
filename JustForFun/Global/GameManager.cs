using JustForFun.FlockingFolder.BoidsFlocking;
using JustForFun.Menu;
using JustForFun.Menu.StarFlight;
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
    public enum TypeOfBehavior
    {
        Flocking,
        Steering,
        CelluarAutomata,
    }
    public enum GameState
    {
        Menu,
        Running,
        Reset,
        Exit,
        Credits,
    }

    class GameManager
    {
        Map map;
        BoidController boidController;
        Enemy enemy;
        Enemy leader;
        SteeringController sController;
        Menu1 menu;

        StarController starcontroller;

        TypeOfBehavior m_CurrentBehavior;
        GameState m_CurrentGameState;

        public GameManager()
        {
            map = new Map();
            starcontroller = new StarController();
            boidController = new BoidController(TextureMananger.tri);
            enemy = new Enemy(300f, 300f);
            leader = new Enemy(600f, 500f);
            leader.m_MaxSpeed = 2;
            sController = new SteeringController();
            menu = new Menu1();
        }

        /// <summary>
        /// Initilize all stuffs
        /// </summary>
        public void Initi()
        {
            map.Initi();
           // map.MakeMap();
        }

        /// <summary>
        /// Loads all stuffs
        /// </summary>
        public void Load()
        {

        }

        void CheckBehavior()
        {

            m_CurrentBehavior = TypeOfBehavior.Flocking;
            switch (m_CurrentBehavior)
            {
                case TypeOfBehavior.Flocking:
                    break;
                case TypeOfBehavior.Steering:
                    break;
                case TypeOfBehavior.CelluarAutomata:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            m_CurrentGameState = GameState.Menu;
            switch (m_CurrentGameState)
            {
                case GameState.Menu:
                    map.UpdateMap(gameTime);
                    //starcontroller.Update(gameTime);
                    //menu.UpdateMenu(ref m_CurrentBehavior, gameTime);
                    break;
                case GameState.Running:
                    break;
                case GameState.Reset:
                    break;
                case GameState.Exit:
                    break;
                case GameState.Credits:
                    break;
                default:
                    break;
            }
            //leader.Wander2(KeyMouseReader1.GetMousePosition(), gameTime);
            //leader.Approach(KeyMouseReader1.GetMousePosition());
            //enemy.Approach(KeyMouseReader1.GetMousePosition());
            //enemy.Wander2(KeyMouseReader1.GetMousePosition(),gameTime);
            //sController.Update(gameTime);
            //enemy.Pursuit(leader);
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

            switch (m_CurrentGameState)
            {
                case GameState.Menu:
                    //starcontroller.Draw(sb);
                    map.Draw(sb);
                    // menu.Draw(sb);
                    break;
                case GameState.Running:
                    break;
                case GameState.Reset:
                    break;
                case GameState.Exit:
                    break;
                case GameState.Credits:
                    break;
                default:
                    break;
            }
            //   sb.Draw(TextureMananger.star, KeyMouseReader1.GetMousePosition(), null, Color.Red, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            //enemy.Draw(sb);
            //sController.Draw(sb);
            // boidController.Draw(sb);
            sb.End();
        }
    }
}
