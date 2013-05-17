using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public abstract class GameObj : IRenderable
    {
        ConsoleColor color;
        public const string CollisionGroupString = "object";
        protected Position position;
        protected char body;

        protected GameObj(Position position, char body, ConsoleColor color)
        {
            this.Color = color;
            this.position = position;
            this.body = body;

            this.IsDestroyed = false;
        }

        public bool IsDestroyed { get; set; }

        public Position Position { get { return this.position; } set { this.position = value; } }

        public bool CanCollideWith(string collisionGroupString)
        {
            return GameObj.CollisionGroupString == collisionGroupString;
        }

        public string GetCollisionGroupString()
        {
            return GameObj.CollisionGroupString;
        }

        public virtual void Die()
        {
            IsDestroyed = true;
        }

        public virtual List<Position> GetCollisionProfile()
        {
            List<Position> profile = new List<Position>();

                    profile.Add(new Position(this.position.Y, this.position.X));

            return profile;
        }

        public virtual void RespondToCollision(CollisionData collisionData) { }
        
        public abstract void Update();

        public ConsoleColor Color { get { return this.color; } set { this.color = value; } }

        public virtual IEnumerable<GameObj> ProduceObjects()
        {
            return new List<GameObj>();
        }
        public char Body { get { return this.body; } set { this.body = value; } }
    }
}
