using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Steering
{
    class LeaderEnemy : Enemy
    {
        public LeaderEnemy(float x, float y) : base(x, y)
        {
            m_Location = new Vector2(x, y);
            m_MaxSpeed = 6f;
        }
    }
}
