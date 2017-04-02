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

        public ParticleManager(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                m_ParticleList[i] = new Particle();
            }
        }

        public void CreateParticle()
        {

        }
    }
}
