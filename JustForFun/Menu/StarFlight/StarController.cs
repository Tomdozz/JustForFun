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
        Star[] stars = new Star[100];

        Random rnd;
        public StarController()
        {
            rnd = new Random();
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(ref rnd);
            }
        }

        public void Update()
        {
            foreach (Star star in stars)
            {

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
