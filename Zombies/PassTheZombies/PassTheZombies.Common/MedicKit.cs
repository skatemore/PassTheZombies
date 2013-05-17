using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public class MedicKit : Item
    {
        public const string CollisionGroupString = "kit";

        public MedicKit(Position topLeft)
            : base(topLeft, 'H', ConsoleColor.Red)
        { }
    }
}
