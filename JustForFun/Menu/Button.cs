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

        public Button(String Text, Rectangle posHitBox)
        {
            m_text = Text;
            m_HitBox = posHitBox;
        }

        public void Update()
        {
            if(m_HitBox.Contains(KeyMouseReader1.GetMousePosition()))
            {

            }
        }

        public void Draw(SpriteBatch sb)
        {
            //sb.Draw()
        }
    }
}
