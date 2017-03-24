using JustForFun.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace JustForFun.Steering
{
    class Enemy
    {
        public Vector2 m_Location;
        protected Vector2 m_Velocity;
        protected Vector2 m_Acceleration;
        protected Vector2 test_Desierd;
        protected Vector2 m_Offset;

        public float m_MaxSpeed;
        protected float m_MaxForce;
        protected float m_Speed = 1;
        protected float m_Radius = 100;
        protected float m_arriveCirkel = 100;
        protected float m_angle = 45;

        protected float m_Ellapsed = 0;

        protected double m_angel2 = 2;
        protected double m_Theta;

        protected double dx;
        protected double dy;

        protected Color color;
        protected Random rnd;

        private static float border = 100f;
        private static float m_Sight = 75f;
        private static float m_Space = 30f;
        //private static float m_Speed = 12f;

        //----flocking

        System.Timers.Timer aTimer = new System.Timers.Timer();

        /// <summary>
        /// All behaviour is based on the desierd vector(current vector - target vector)
        /// and result in a force vector that is sent to the applyForce method
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Enemy(float x, float y)
        {
            m_Acceleration = new Vector2(0, 0);
            m_Velocity = new Vector2(2, 2);
            m_Location = new Vector2(x, y);
            Vector2 test_Desierd = new Vector2(0, 0);

            m_Radius = 100;
            m_MaxSpeed = 1.5f;
            m_MaxForce = 1.01f;
            rnd = new Random();

        }

        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Get a random value between two values
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public double GetRandomNumber(double minimum, double maximum)
        {
            return rnd.NextDouble() * (maximum - minimum) + minimum;
        }

        public void Move(List<Enemy> enemys)
        {
            Flock(enemys);
            m_Location.X += (float)dx;
            m_Location.Y += (float)dy;

        }

        void Flock(List<Enemy> enemys)
        {
            foreach (Enemy enemy in enemys)
            {
                float distance = Distance(m_Location, enemy.m_Location);

                    if (distance < m_Space)
                    {
                        // Skapa space.
                        dx += m_Location.X - enemy.m_Location.X;
                        dy += m_Location.Y - enemy.m_Location.Y;
                    }
                    else if (distance < m_Sight)
                    {
                        // Flock ihop.
                        dx += (enemy.m_Location.X - m_Location.X) * 0.05f;
                        dy += (enemy.m_Location.Y - m_Location.Y) * 0.05f;
                    }
                    if (distance < m_Sight)
                    {
                        //Ser inga andra boid och vill komma till dom.
                        dx += enemy.dx * 0.5f;
                        dy += enemy.dy * 0.5f;
                    }
            }
        }

        private static float Distance(Vector2 p1, Vector2 p2)
        {
            double val = Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2);
            return (float)Math.Sqrt(val);
        }

        /// <summary>
        /// Applys forces to the enemy and checks if the enemy is in the window bounds
        /// </summary>
        /// <param name="steering"></param>
        void ApplyForce(Vector2 steering)
        {
            m_Location += steering;

            if (m_Location.X < 0)
            {
                m_Location.X = Fixed.windowWidth;
            }
            if (m_Location.Y < 0)
            {
                m_Location.Y = Fixed.windowHeight;
            }
            if (m_Location.X > Fixed.windowWidth)
            {
                m_Location.X = 0;
            }
            if (m_Location.Y > Fixed.windowHeight)
            {
                m_Location.Y = 0;
            }
        }
        /// <summary>
        /// Approach behavior
        /// Used many times by the other steeringMethods
        /// </summary>
        /// <param name="target"></param>
        public void Approach(Vector2 target)
        {
            Vector2 m_Desired = Vector2.Subtract(target, m_Location);

            m_Desired.Normalize();
            m_Desired = Vector2.Multiply(m_Desired, m_MaxSpeed);
            m_Velocity = Vector2.Multiply(m_Desired, -m_Speed);

            if (m_Velocity.Length() > m_MaxSpeed)
            {
                m_Velocity = (m_Velocity / m_Velocity.Length()) * m_MaxSpeed;
            }
            //Console.WriteLine(m_Velocity);

            Vector2 m_Steering = Vector2.Subtract(m_Desired, m_Velocity);
            //Console.WriteLine(m_Steering);

            if (m_Steering.Length() > m_MaxForce)
            {
                m_Steering = Vector2.Multiply(m_Steering, m_MaxForce);
            }
            ApplyForce(m_Steering);
        }

        /// <summary>
        /// Calculates a vecktor in front of the leader and calls approach to go towards that position
        /// </summary>
        /// <param name="leader"></param>
        public void Pursuit(Enemy leader)
        {
            Vector2 m_futureLeaderPos = leader.m_Location + leader.m_Velocity * 2;
            test_Desierd = m_futureLeaderPos;
            Approach(m_futureLeaderPos);
        }

        /// <summary>
        /// Wanderbeavior
        /// </summary>
        /// <param name="target"></param>
        public void Wander(Vector2 target, GameTime gameTime)
        {

            m_angle += (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 m_Desired = Vector2.Subtract(target, m_Location);
            m_Desired.X += (float)Math.Cos(m_angle) * m_Radius;
            m_Desired.Y += (float)Math.Sin(m_angle) * m_Radius;

            m_Desired.Normalize();
            m_Velocity = Vector2.Multiply(m_Desired, -m_Speed);
            Vector2 m_Steering = Vector2.Subtract(m_Desired, m_Velocity);
            //max force
            // test_Desierd = m_Desired;
            ApplyForce(m_Steering);

        }

        /// <summary>
        /// Wander behavior
        /// </summary>
        /// <param name="target"></param>
        /// <param name="gameTime"></param>
        public void Wander2(Vector2 target, GameTime gameTime)
        {
            //461
            Vector2 m_Center = m_Velocity;
            m_Center.Normalize();
            m_Center *= 15;
            m_Center += m_Location;

            m_Ellapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (m_Ellapsed > 150)
            {
                m_angle += (float)GetRandomNumber(-0.20f, 0.20f);
                m_Ellapsed = 0;
            }

            Vector2 m_CercleTarget = new Vector2((float)Math.Cos(m_angle) * m_Radius, (float)Math.Sin(m_angle) * m_Radius);

            Vector2 m_target = m_Center + m_CercleTarget;

            test_Desierd = m_target;
            Approach(m_target);
        }

        /// <summary>
        /// ArriveBehavior
        /// </summary>
        /// <param name="target"></param>
        public void Arrive(Vector2 target)
        {
            Vector2 m_Desired = Vector2.Subtract(target, m_Location);
            double d = Math.Sqrt((m_Desired.X * m_Desired.X) + (m_Desired.Y * m_Desired.Y));

            if (d < m_arriveCirkel)
            {
                m_Desired.Normalize();
                m_Velocity = Vector2.Multiply(m_Desired, -m_Speed * ((float)d / m_arriveCirkel));
            }
            else
            {
                m_Desired.Normalize();
                m_Velocity = Vector2.Multiply(m_Desired, -m_Speed);
            }

            Vector2 m_Steering = Vector2.Subtract(m_Desired, m_Velocity);
            //maxforce
            ApplyForce(m_Steering);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(TextureMananger.tri, m_Location, Color.White);
            sb.Draw(TextureMananger.tri, test_Desierd, Color.Red);
        }
    }
}
