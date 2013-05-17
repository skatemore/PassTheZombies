using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public interface IRenderable
    {
        ConsoleColor Color { get; set; }
        Position Position { get; set; }
        char Body{get; set;}
    }
}
