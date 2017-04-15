using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Global
{
    class TextureMananger
    {
        public static Texture2D cell;
        public static Texture2D grid;
        public static Texture2D tri;
        public static Texture2D star;

        public static SpriteFont menuFont;

        public void LoadTexture(ContentManager Content)
        {
            cell = Content.Load<Texture2D>("pixel");
            grid = Content.Load<Texture2D>("grid");
            tri = Content.Load<Texture2D>("tri");
            star = Content.Load<Texture2D>("star1");
            menuFont = Content.Load<SpriteFont>("ca");

        }
    }
}
