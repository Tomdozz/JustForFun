using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Particles
{
    class ParticleManager
    {
        /// <summary>
        /// Fattar inte läs sen
        /// </summary>
        private class RotatetParticleArray
        {
            private int m_Start;

            public int Start
            {
                get { return m_Start; }
                set { m_Start = value % list.Length; }
            }

            //Active particles
            public int Count { get; set; }
            public int Capacity { get { return list.Length; } }
            private Particle[] list;

            public RotatetParticleArray(int capacity)
            {
                list = new Particle[capacity];
            }

            public Particle this[int i]
            {
                get { return list[(m_Start + i) % list.Length]; }
                set { list[(m_Start + i) % list.Length] = value; }
            }
        }

        private Particle[] m_ParticleList;
        private int m_Capacity;

        private int m_Count;
        private int m_Start;

        public ParticleManager(int capacity)
        {
            m_Capacity = capacity;
            for (int i = 0; i < capacity; i++)
            {
                m_ParticleList[i] = new Particle();
            }
        }

        public void CreateParticle(Texture2D texture, Color color, Vector2 pos, Vector2 goal, float scale, float orientation, float duartion)
        {
            Particle particle;
            if (m_ParticleList.Count() == m_Capacity)
            {
                particle = m_ParticleList[0];
                m_Start++;
            }
            else
            {
                particle = m_ParticleList[m_Count];
                m_Count++;
            }
            particle.m_Texture = texture;
            particle.m_Position = pos;
            particle.m_Color = color;
            particle.m_Scale = scale;
            particle.m_Orientation = orientation;
            particle.m_Duration = duartion;
            particle.m_Goal = goal;
        }

        public void UpdateParticle(Particle particle)
        {
            particle.m_Desired = Vector2.Subtract(particle.m_Goal, particle.m_Position);
            double d = Math.Sqrt((particle.m_Desired.X * particle.m_Desired.X) + (particle.m_Desired.Y * particle.njm_Desired.Y));

        }

        public void Draw(SpriteBatch sb)
        {

        }
    }
}
