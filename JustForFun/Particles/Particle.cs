using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Particles
{
    class Particle
    {
        public Texture2D m_Texture;
        public Color m_Color;

        public Vector2 m_Position;
        public Vector2 m_Goal;
        public Vector2 m_Desired;
        public Vector2 m_ScaleVector = Vector2.One;

        public float m_Scale;
        public float m_Orientation;
        public float m_Duration;
        public float m_PercentLife = 1f;
    }
}
