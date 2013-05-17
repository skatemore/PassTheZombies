using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public interface IMovable
    {
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
    }
}
