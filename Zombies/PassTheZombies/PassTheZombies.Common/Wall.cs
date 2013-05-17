using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public class Wall : Obstacle
    {
        public const string CollisionGroupString = "wallhor";

        public Wall(Position topLeft)
            : base(topLeft, '█', ConsoleColor.Blue)
        {
        }
    }
}
