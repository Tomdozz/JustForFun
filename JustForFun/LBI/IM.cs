using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.LBI
{
    class IM
    {
        float[,] m_influences;
        float[,] m_influenceBuffer;

        public float Width{get { return m_influences.GetLength(1); }}
        public float Height{get { return m_influences.GetLength(0); }}

        public float Decay { get; set; }
        public float Momentum { get; set; }

        public IM(int size, float decay, float momentum)
        {
            m_influences = new float[size, size];
            m_influenceBuffer = new float[size, size];
            Decay = decay;
            Momentum = momentum;
        }

        public float GetVal(int x, int y)
        {
            return m_influences[x, y];
        }

        public void SetInfluence(int x, int y, float val)
        {
            if (x< Width && y < Height)
            {
                m_influences[x, y] = val;
                m_influences[x, y] = val;
            }
           //Console.WriteLine("hey you cant add this val");
        }
    }
}
