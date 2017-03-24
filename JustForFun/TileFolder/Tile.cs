using JustForFun.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.TileFolder
{
    public class Tile
    {
        Fixed fix; 
        public Vector2 pos;
        public Texture2D tex;
        public Rectangle textRec;

        protected Rectangle checkRec;

        public int tileSize = 50;
        public int tileWidth, tileHeight;

        /// <summary>
        /// Get position
        /// </summary>
        /// <returns></returns>
        public virtual Vector2 Position()
        {
            return pos;
        }

        /// <summary>
        /// Get tilepoint
        /// </summary>
        public virtual Point TilePoint
        {
            get { return new Point((int)pos.X, (int)pos.Y); }
        }

        //public Rectangle HitBox()
        //{
        //    return new Rectangle;
        //}

        public Tile(Vector2 pos, Texture2D tex)
        {
            this.pos = pos;
            this.tex = tex;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, new Rectangle((int)pos.X, (int)pos.Y, Fixed.cellSize, Fixed.cellSize), Color.White,0, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }

    }
}
