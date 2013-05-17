using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public abstract class Human : GameObj, ICollidable, IMovable, IHealable, IKillable
    {
        public Position Memento { get; protected set; }

        private int health = 100;
        public string CollisionGroupString = "human";

        public Human(Position position, char body, int health, ConsoleColor color)
            : base(position, body, color)
        {
            Health = health;
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public void Heal(int amount)
        {
            this.health += amount;
            if (this.health > 100)
            {
                this.health = 100;
            }
        }

        public override void Update() { }

        public void MoveLeft()
        {
            this.Memento = this.Position;
            this.Position.X--;
        }

        public void MoveRight()
        {
            this.Memento = this.Position;
            this.Position.X++;
        }

        public void MoveUp()
        {
            this.Memento = this.Position;
            this.Position.Y--;
        }

        public void MoveDown()
        {
            this.Memento = this.Position;
            this.Position.Y++;
        }


        public virtual void RespondToCollision()
        {
        }
    }
}
