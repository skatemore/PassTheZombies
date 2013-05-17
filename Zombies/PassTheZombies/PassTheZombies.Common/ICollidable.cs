using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public interface ICollidable
    {
        bool CanCollideWith(string objectType);

        void RespondToCollision();

        string GetCollisionGroupString();
    }
}
