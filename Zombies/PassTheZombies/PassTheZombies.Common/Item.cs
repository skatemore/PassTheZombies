using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public class Item : GameObj, ITakeable, IKillable
    {
        public const string CollisionGroupString = "item";

        public Item(Position topLeft, char body, ConsoleColor color)
            : base(topLeft, body, color)
        {
        }

        public virtual void Take() { }
        public override void Update() { }

    }
}
