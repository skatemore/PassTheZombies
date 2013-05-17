using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj);
        void RenderAll();
        void ClearQueue();
        void ClearConsole(int cellsCount);
        void ClearTrail(Position position);
    }
}
