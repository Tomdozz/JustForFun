using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Menu
{
    class Button
    {
        Rectangle m_HitBox;
        String m_text;

        public Button(String Text, Rectangle posHitBox)
        {
            m_text = Text;
            m_HitBox = posHitBox;
        }

        public void Draw(SpriteBatch sb)
        {
            //sb.Draw()
        }
    }
}
