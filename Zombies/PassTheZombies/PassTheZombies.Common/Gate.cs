using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public class Gate : Obstacle
    {
        public Gate(Position position) : base(position, 'G', ConsoleColor.Green)
        {

        }
    }
}
