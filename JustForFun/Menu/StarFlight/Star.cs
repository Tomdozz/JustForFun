using JustForFun.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Menu.StarFlight
{
    class Star
    {
        float m_X;
        float m_Y;
        float m_Z;

        Vector2 m_Position;

        //private static Random rnd;
        public Star(ref Random rnd)
        {
            m_X = rnd.Next(0, Fixed.windowWidth);
            m_Y = rnd.Next(0, Fixed.windowHeight);
            m_Z = rnd.Next(0, Fixed.windowWidth);
        }

        //public float GetRandomNumber(float minimum, float maximum)
        //{
            //return (float)(rnd.NextDouble() * (maximum - minimum) + minimum);
        //}

        public void Update()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(TextureMananger.tri, new Vector2(m_X,m_Y), Color.White);
        }
    }
}
