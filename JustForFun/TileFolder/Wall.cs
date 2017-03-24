using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.TileFolder
{
    public class Wall:Tile
    {    
        //aka cell
        public Wall(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            this.pos = pos;
            this.tex = tex;
        }

    }
}

