using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Steering
{
    class Enemy
    {
        Color       m_Color;
        Vector2     m_Pos;
        Vector2     m_Velocity;
        Texture2D   m_Tex;
        float       m_Speed;

        public Enemy(Vector2 pos)
        {
            m_Pos = pos;
        }

        public void Update(Vector2 goTo, float speed)
        {
            Vector2 dir = goTo - m_Pos;
            dir.Normalize();

            m_Velocity = Vector2.Multiply(dir, speed);
            m_Pos += m_Velocity;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(m_Tex, m_Pos, Color.Red);
        }
    }
}
