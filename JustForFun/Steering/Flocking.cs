using Microsoft.Xna.Framework;
using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.Steering
{
    class Flocking
    {
        public List<Enemy> enemys = new List<Enemy>();
        LeaderEnemy leader;
        int offset = 0;

        public Flocking(int numEnemies)
        {
            for (int i = 0; i < numEnemies; i++)
            {
                ++offset;
                enemys.Add(new Enemy(100 + offset, 100 + offset));
            }

            leader = new LeaderEnemy(300,300);
        }

        public void MoveEnemys(GameTime time)
        {
            leader.Approach(KeyMouseReader1.GetMousePosition());
            foreach (Enemy enemy in enemys)
            {
                //enemy.Move(enemys);
                enemy.Pursuit(leader);
            }
        }
    }
}
