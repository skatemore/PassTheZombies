using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public class ConsoleRenderer : IRenderer
    {
        List<IRenderable> objects = new List<IRenderable>();
        Queue<Position> visitedPositions = new Queue<Position>();

        public void EnqueueForRendering(IRenderable obj)
        {
            objects.Add(obj);
        }

        public void ClearTrail(Position position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(' ');
        }

        public void RenderAll()
        {
            //Console.Clear();
            for (int i = 0; i < objects.Count; i++)
            {
                IRenderable obj = objects[i];
                Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                Console.ForegroundColor = obj.Color;
                Console.Write(obj.Body);
            }
        }

        public void ClearQueue()
        {
            objects.Clear();
        }

        public void ClearConsole(int cellsCount)
        {
            StringBuilder eraser = new StringBuilder();
            for (int i = 0; i < cellsCount; i++)
            {
                eraser.Append(' ');
            }
            Console.SetCursorPosition(0,0);
            Console.Write(eraser.ToString());
        }
    }
}
