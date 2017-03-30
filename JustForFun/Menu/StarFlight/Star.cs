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

        float m_dir;
        float m_Speed = 2;

        float m_Scale = 0.005f;

        Vector2 m_Position;
        Vector2 m_Goal;
        Vector2 m_Velocity;
        Vector2 m_DrawPos;

        //private static Random rnd;
        public Star(ref Random rnd)
        {
            m_X = rnd.Next(Fixed.windowWidth/2-40, Fixed.windowWidth/2+40);
            m_Y = rnd.Next(Fixed.windowHeight/2-40, Fixed.windowHeight/2+40);
            m_Z = rnd.Next(0, Fixed.windowWidth);

            m_dir = rnd.Next(0, 4);
            if (m_dir == 0)
            {
                m_Goal = new Vector2(rnd.Next(Fixed.windowWidth - 30, Fixed.windowWidth), rnd.Next(0, Fixed.windowHeight));
            }
            if (m_dir == 1)
            {
                m_Goal = new Vector2(rnd.Next(0, 30), rnd.Next(0, Fixed.windowHeight));
            }
            if (m_dir == 2)
            {
                m_Goal = new Vector2(rnd.Next(0, Fixed.windowWidth), rnd.Next(Fixed.windowHeight-30, Fixed.windowHeight));
            }
            if (m_dir == 3)
            {
                m_Goal = new Vector2(rnd.Next(0, Fixed.windowWidth), rnd.Next(0, 30));
            }
            m_Position = new Vector2(m_X, m_Y);
        }

        public void Update()
        {
            Vector2 m_Desired = Vector2.Subtract(m_Goal, m_Position);
            double d = Math.Sqrt((m_Desired.X * m_Desired.X) + (m_Desired.Y * m_Desired.Y));

            m_Scale = m_Scale + 0.000005f;
                //-((float)d/1000000000);

            m_Desired.Normalize();
            m_Desired = Vector2.Multiply(m_Desired, m_Speed);
            m_Velocity = Vector2.Multiply(m_Desired, -m_Speed);

            Vector2 m_Steer = Vector2.Subtract(m_Desired, m_Velocity);

            m_Position += m_Steer;
        }

        public void Draw(SpriteBatch sb)
        {
            //sb.Draw(TextureMananger.tri, new Vector2(m_X,m_Y), Color.White);


            sb.Draw(TextureMananger.star, m_Position, null, Color.White, 0, new Vector2(0, 0), m_Scale, SpriteEffects.None, 0);
        }
    }
}
