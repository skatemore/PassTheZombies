using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTheZombies.Common
{
    public class GameEngine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObj> allObjects;
        List<Zombie> movingObjects;
        List<GameObj> staticObjects;
        Player player;
        int cellsCount;

        public GameEngine(IRenderer renderer, IUserInterface userInterface, int cellsCount)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObj>();
            this.movingObjects = new List<Zombie>();
            this.staticObjects = new List<GameObj>();
            this.cellsCount = cellsCount;
        }

        public virtual void AddObject(GameObj obj)
        {

            if (obj is Player)
            {
                AddRacket(obj);
                AddStaticObject(obj);
            }
            else
            {
                this.AddStaticObject(obj);
            }
        }

        private void AddMovingObject(Zombie obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddStaticObject(GameObj obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }


        private void AddRacket(GameObj obj)
        {
            this.player = obj as Player;
        }
        bool doorFlagClosed = true;
        public virtual void MovePlayerLeft()
        {
            bool flag = true;
            foreach (var item in staticObjects)
            {
                if (item is Wall)
                {
                    if (item.Position.X == this.player.Position.X - 1 && item.Position.Y == this.player.Position.Y)
                    {
                        flag = false;
                        break;
                    }
                }
                else if (item is Gate)
                {
                    if (item.Position.X == this.player.Position.X - 1 && item.Position.Y == this.player.Position.Y && doorFlagClosed)
                    {
                        flag = false;
                        break;
                    }
                    else if (!doorFlagClosed && item.Position.X == this.player.Position.X - 1 && item.Position.Y == this.player.Position.Y)
                    {
                        Console.Clear();
                        Console.WriteLine("Good Job!");
                        Console.WriteLine("Remaining health:{0}",this.player.Health);
                        System.Threading.Thread.Sleep(5000);
                    }
                }
                else if (item is Key)
                {
                    if (item.Position.X == this.player.Position.X - 1 && item.Position.Y == this.player.Position.Y)
                    {
                        item.IsDestroyed = true;
                        doorFlagClosed = false;
                        break;
                    }
                }
                else if (item is Zombie)
                {
                    if (item.Position.X == this.player.Position.X - 1 && item.Position.Y == this.player.Position.Y)
                    {
                        this.player.GetDamage();
                    }
                }
                
                
            }
            if (flag == true)
            {
                renderer.ClearTrail(player.Position);
                this.player.MoveLeft();
            }

        }

        public virtual void MovePlayerRight()
        {
            bool flag = true;
            foreach (var item in staticObjects)
            {
                if (item is Wall)
                {
                    if (item.Position.X == this.player.Position.X + 1 && item.Position.Y == this.player.Position.Y)
                    {
                        flag = false;
                        break;
                    }
                }
                else if (item is Gate)
                {
                    if (item.Position.X == this.player.Position.X + 1 && item.Position.Y == this.player.Position.Y && doorFlagClosed)
                    {
                        flag = false;
                        break;
                    }
                    else if (!doorFlagClosed && item.Position.X == this.player.Position.X + 1 && item.Position.Y == this.player.Position.Y)
                    {
                        Console.Clear();
                        Console.WriteLine("Good Job!");
                        System.Threading.Thread.Sleep(5000);
                    }
                }
                else if (item is Key)
                {
                    if (item.Position.X == this.player.Position.X + 1 && item.Position.Y == this.player.Position.Y)
                    {
                        item.IsDestroyed = true;
                        doorFlagClosed = false;
                        break;
                    }
                }
                else if (item is Zombie)
                {
                    if (item.Position.X == this.player.Position.X + 1 && item.Position.Y == this.player.Position.Y)
                    {
                        this.player.GetDamage();
                    }
                }

            }
            if (flag == true)
            {
                renderer.ClearTrail(player.Position);
                this.player.MoveRight();
            }
        }

        public virtual void MovePlayerUp()
        {
            bool flag = true;
            foreach (var item in staticObjects)
            {
                if (item is Wall)
                {
                    if (item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y - 1)
                    {
                        flag = false;
                        break;
                    }
                }
                else if (item is Gate)
                {
                    if (item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y - 1 && doorFlagClosed)
                    {
                        flag = false;
                        break;
                    }
                    else if (!doorFlagClosed && item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y - 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Good Job!");
                        System.Threading.Thread.Sleep(5000);
                    }
                }
                else if (item is Key)
                {
                    if (item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y - 1)
                    {
                        item.IsDestroyed = true;
                        doorFlagClosed = false;
                        break;
                    }
                }
                else if (item is Zombie)
                {
                    if (item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y - 1)
                    {
                        this.player.GetDamage();
                    }
                }
               
            }
            if (flag == true)
            {
                renderer.ClearTrail(player.Position);
                this.player.MoveUp();
            }

        }

        public virtual void MovePlayerDown()
        {
            bool flag = true;
            foreach (var item in staticObjects)
            {
                if (item is Wall)
                {
                    if (item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y + 1)
                    {
                        flag = false;
                        break;
                    }
                }
                else if (item is Gate)
                {
                    if (item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y + 1 && doorFlagClosed)
                    {
                        flag = false;
                        break;
                    }
                    else if (!doorFlagClosed && item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y + 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Good Job!");
                        System.Threading.Thread.Sleep(5000);
                    }
                }
                else if (item is Key)
                {
                    if (item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y + 1)
                    {
                        item.IsDestroyed = true;
                        doorFlagClosed = false;
                        break;
                    }
                }
                else if (item is Zombie)
                {
                    if (item.Position.X == this.player.Position.X && item.Position.Y == this.player.Position.Y + 1)
                    {
                        this.player.GetDamage();
                        if (this.player.IsDestroyed)
                        {
                            Console.Clear();
                            Console.WriteLine("Game Over!");
                            System.Threading.Thread.Sleep(5000);
                        }
                    }
                }
                
                
            }
            if (flag == true)
            {
                this.player.MoveDown();
            }

        }

       

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();
                System.Threading.Thread.Sleep(100);
                this.userInterface.ProcessInput();
                this.renderer.ClearQueue();
                this.renderer.ClearConsole(cellsCount);
                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);
                List<GameObj> producedObjects = new List<GameObj>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }
    }
}
