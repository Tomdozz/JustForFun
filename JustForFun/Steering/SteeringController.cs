using JustForFun.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Steering
{
    //444
    class SteeringController
    {
        //approach
        //      -Styr direkt mot obj
        //pursuit
        //      -Rör mot vektor framför spelaren
        //evade
        //      -Motsatsen mot pursuit
        //      -åk iväg från 
        //Arraive
        //      -Åker mot en punkt
        //      -Sakta in
        //Wander
        //      -åk runt en cirkel
        Texture2D   texture;
        Flocking flock;

        public SteeringController()
        {
            //this.texture = texture;
            flock = new Flocking(5);
        }
        public void initi()
        {

        }
        public void Update(GameTime gameTime)
        {
            flock.MoveEnemys(gameTime);
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Enemy enemy in flock.enemys)
            {
                sb.Draw(TextureMananger.tri, enemy.m_Location, Color.White);
            }
        }

        void Reset()
        {

        }
    }
}
