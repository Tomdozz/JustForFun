using JustForFun.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.FlockingFolder.BoidsFlocking
{
    class BoidController
    {
        Texture2D texture;
        FlockControl flockControl;
        //handle drawing and stuffs
        public BoidController(Texture2D texture)
        {
            this.texture = texture;
            flockControl = new FlockControl(700);
        }

        public void Update()
        {
            flockControl.MoveBoids();
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Boid1 boid in flockControl.boids)
            {
                sb.Draw(TextureMananger.tri, boid.Position, Color.White);
            }
        }
    }
}
