using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public abstract class Obstacle : GameObj, ICollidable
    {
        public const string CollisionGroupString = "obstacle";

        public Obstacle(Position position, char body, ConsoleColor color)
            : base(position, body, color)
        {

        }

        public override void Update()
        {
        }


        public virtual void RespondToCollision()
        {
            throw new NotImplementedException();
        }
    }
}
