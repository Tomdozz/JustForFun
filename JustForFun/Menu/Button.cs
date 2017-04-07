using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Menu
{
    enum ButtonState
    {
        Hovering,
        Clicked,
        JustClicked,
        Neutral
    }
    class Button
    {
        Rectangle m_HitBox;
        Color m_Color;
        String m_text;
        SpriteFont m_font;

        public Button(String Text, Rectangle posHitBox, SpriteFont font)
        {
            m_text = Text;
            m_HitBox = posHitBox;
            m_Color = Color.Gray;
            m_font = font;
        }

        public void Update()
        {
            if(m_HitBox.Contains(KeyMouseReader1.GetMousePosition()))
            {
                m_Color = Color.White;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(m_font, m_text, new Vector2(m_HitBox.X, m_HitBox.Y), m_Color);
            //sb.Draw()
        }
    }
}
