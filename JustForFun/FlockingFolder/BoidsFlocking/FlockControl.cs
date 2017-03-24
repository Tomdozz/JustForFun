using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForFun.FlockingFolder.BoidsFlocking
{
    class FlockControl
    {
        public List<Boid1> boids = new List<Boid1>();

        public FlockControl(int boundary)
        {
            for (int i = 0; i < 17; i++)
            {
                boids.Add(new Boid1((i > 14), boundary));
            }
        }

      // public void CreateFlock(int flockSize)
      // {
      //     for (int i = 0; i < flockSize; i++)
      //     {
      //         boids.Add(new Boid1(2));
      //     }
      // }

        public void MoveBoids()
        {
            foreach (Boid1 boid in boids)
            {
                boid.Move(boids);
            }
        }
    }
}
