using JustForFun.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Menu.StarFlight
{
    class Star
    {
        public Vector2 m_Position;
        public Vector2 m_Goal;
        public float m_Checkvalue;

        float m_X;
        float m_Y;
        float m_Z;
        float m_dir;
        float m_Speed =1.1f;
        float m_Startdelay;

        float m_Scale = 0.01f;

        Vector2 m_Startposition;
        Vector2 m_Velocity;
        Vector2 m_Steer;


        protected float m_Ellapsed = 0;
        Random random;

        //private static Random rnd;
        public Star(ref Random rnd)
        {
            m_X = rnd.Next(Fixed.windowWidth / 2, Fixed.windowWidth / 2);
            m_Y = rnd.Next(Fixed.windowHeight / 2, Fixed.windowHeight / 2);
            m_Z = rnd.Next(0, Fixed.windowWidth);

            m_Startdelay = rnd.Next(0, 50);
            //m_Speed = rnd.Next(0, 2);

            m_dir = rnd.Next(0, 4);
            if (m_dir == 0) { m_Goal = new Vector2(rnd.Next(Fixed.windowWidth, Fixed.windowWidth + 30), rnd.Next(0, Fixed.windowHeight)); }
            if (m_dir == 1) { m_Goal = new Vector2(rnd.Next(-30, 0), rnd.Next(0, Fixed.windowHeight)); }
            if (m_dir == 2) { m_Goal = new Vector2(rnd.Next(0, Fixed.windowWidth), rnd.Next(Fixed.windowHeight, Fixed.windowHeight + 30)); }
            if (m_dir == 3) { m_Goal = new Vector2(rnd.Next(0, Fixed.windowWidth), rnd.Next(-30, 0)); }

            m_Position = new Vector2(m_X, m_Y);
            m_Startposition = new Vector2(m_X, m_Y);
            random = new Random();
        }

        public void Reset(GameTime gameTime, ref Random rnd)
        {
            m_dir = rnd.Next(0, 4);
            if (m_dir == 0){m_Goal = new Vector2(rnd.Next(Fixed.windowWidth, Fixed.windowWidth+30), rnd.Next(0, Fixed.windowHeight));}
            if (m_dir == 1){m_Goal = new Vector2(rnd.Next(-30, 0), rnd.Next(0, Fixed.windowHeight));}
            if (m_dir == 2){m_Goal = new Vector2(rnd.Next(0, Fixed.windowWidth), rnd.Next(Fixed.windowHeight, Fixed.windowHeight +30));}
            if (m_dir == 3){m_Goal = new Vector2(rnd.Next(0, Fixed.windowWidth), rnd.Next(-30, 0));}

            m_Ellapsed = 0;
            m_Position = KeyMouseReader1.GetMousePosition();
            m_Scale = 0.01f;          
        }

        public void Update(GameTime gameTime)
        {
            m_Ellapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                Vector2 m_Desired = Vector2.Subtract(m_Goal, m_Position);
                double d = Math.Sqrt((m_Desired.X * m_Desired.X) + (m_Desired.Y * m_Desired.Y));

                m_Checkvalue = (float)d;
                m_Scale += m_Scale/(float)d;
                //-((float)d/1000000000);

                m_Desired.Normalize();
                m_Desired = Vector2.Multiply(m_Desired, m_Speed);
                m_Velocity = Vector2.Multiply(m_Desired, -m_Speed);

                m_Steer = Vector2.Subtract(m_Desired, m_Velocity);
                m_Position += m_Steer;        
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(TextureMananger.star, m_Position, null, Color.White, 0, new Vector2(0, 0), m_Scale, SpriteEffects.None, 0);
        }
    }
}
