using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    // SINGLETON PLAYER CLASS
    public class Player : Human
    {
        public const string CollisionGroupString = "player";
        static Player instance;

        private Player(Position position, int health)
            : base(position, 'o', health, ConsoleColor.Cyan)
        { }

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player(new Position(10, 30), 100);
                }
                return instance;
            }
        }

        public void GetDamage() 
        {
            this.Health-=10;
            if (this.Health<1)
            {
                this.IsDestroyed=true;
            }
        }

        public override void Update() { }

    }
}
