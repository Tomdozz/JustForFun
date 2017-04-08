using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Menu.StarFlight
{
    class StarController
    {
        Star[] stars = new Star[70000];

        Random rnd;
        public StarController()
        {
            rnd = new Random();
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(ref rnd);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Star star in stars)
            {
                if(star.m_Checkvalue < 5)
                {
                    star.Reset(gameTime, ref rnd);
                }
                star.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Star star in stars)
            {
                star.Draw(sb);
            }
        }
    }
}
