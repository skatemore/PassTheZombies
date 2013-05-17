using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public class Key : Item
    {
        public const string CollisionGroupString = "key";

        public Key(Position topLeft)
            : base(topLeft, 'K', ConsoleColor.Yellow)
        { }

    }
}
