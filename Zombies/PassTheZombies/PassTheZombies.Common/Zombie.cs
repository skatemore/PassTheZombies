using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public class Zombie : Human
    {
        public Position Speed { get; protected set; }
        public const string CollisionGroupString = "zombie";

        public Zombie(Position topLeft, int health) 
            :base(topLeft, '#', health, ConsoleColor.DarkYellow)
        { }

        protected virtual void UpdatePosition()
        {
            this.position.X += this.Speed.X;
            this.position.Y += this.Speed.Y;
        }

        //public override void Update()
        //{
        //    this.UpdatePosition();
        //}
    }
}
