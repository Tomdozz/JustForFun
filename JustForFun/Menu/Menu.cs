using JustForFun.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Menu
{
    class Menu1
    {
        List<Button> buttons = new List<Button>();

        public Menu1()
        {
            buttons.Add(new Button("Coose state", new Rectangle (Fixed.windowWidth/2, Fixed.windowHeight, 40,40), TextureMananger.menuFont));
        }

        public void UpdateMenu(ref TypeOfBehavior currentBehavior, GameTime gameTime)
        {
            foreach (Button button in buttons)
            {
                button.Update();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Button button in buttons)
            {
                button.Draw(sb);
            }
        }
    }
}
