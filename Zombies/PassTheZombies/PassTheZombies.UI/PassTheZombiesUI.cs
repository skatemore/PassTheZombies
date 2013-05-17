using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassTheZombies.Common;

namespace PassTheZombies.UI
{
    class PassTheZombiesUI
    {
        const int GAME_FIELD_WIDTH = 100;
        const int GAME_FIELD_HEIGHT = 40;

        static void Main(string[] args)
        {


            Console.Clear();
            ConsoleRenderer gameRenderer = new ConsoleRenderer();
            KeyboardInterface controls = new KeyboardInterface();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WindowWidth = Console.BufferWidth = GAME_FIELD_WIDTH + 1;
            Console.WindowHeight = Console.BufferHeight = GAME_FIELD_HEIGHT + 1;
           // DoubleBuffer.buffer bf = new DoubleBuffer.buffer(GAME_FIELD_WIDTH, GAME_FIELD_HEIGHT-1, GAME_FIELD_WIDTH, GAME_FIELD_HEIGHT-1);
            Console.CursorVisible = false;
           
            

            GameEngine ZEUS = new GameEngine(gameRenderer, controls, GAME_FIELD_WIDTH + 1 * GAME_FIELD_HEIGHT + 1);

            controls.OnLeftPressed += (sender, eventInfo) =>
            {
                ZEUS.MovePlayerLeft();
            };

            controls.OnRightPressed += (sender, eventInfo) =>
            {
                ZEUS.MovePlayerRight();
            };

            controls.OnUpPressed += (sender, eventInfo) =>
            {
                ZEUS.MovePlayerUp();
            };
            controls.OnDownPressed += (sender, eventInfo) =>
            {
                ZEUS.MovePlayerDown();
            };

            InitializeEngine(ZEUS);
            ZEUS.Run();
        }

        private static void InitializeEngine(GameEngine engine)
        {
            for (int i = 0; i < GAME_FIELD_WIDTH; i++)
            {
                engine.AddObject(new Wall(new Position(i, 0)));
                engine.AddObject(new Wall(new Position(i, GAME_FIELD_HEIGHT)));
            }

            for (int i = 0; i < GAME_FIELD_HEIGHT; i++)
            {
                engine.AddObject(new Wall(new Position(0, i)));
                engine.AddObject(new Wall(new Position(GAME_FIELD_WIDTH, i)));
            }

            for (int i = 0; i < GAME_FIELD_WIDTH - 50; i++)
            {
                engine.AddObject(new Wall(new Position(i, GAME_FIELD_HEIGHT - 10)));
            }

            for (int i = GAME_FIELD_HEIGHT - 10; i < GAME_FIELD_HEIGHT - 2; i++)
            {
                engine.AddObject(new Wall(new Position(GAME_FIELD_WIDTH - 50, i)));
            }

            for (int i = GAME_FIELD_HEIGHT - 20; i < GAME_FIELD_HEIGHT; i++)
            {
                engine.AddObject(new Wall(new Position(GAME_FIELD_WIDTH - 25, i)));
            }

            for (int i = GAME_FIELD_WIDTH - 60; i < GAME_FIELD_WIDTH - 4; i++)
            {
                engine.AddObject(new Wall(new Position(i, GAME_FIELD_HEIGHT - 21)));
            }

            for (int i = 1; i <( GAME_FIELD_WIDTH >> 1); i++)
            {
                engine.AddObject(new Wall(new Position(i, GAME_FIELD_HEIGHT - 26)));
            }

            for (int i = GAME_FIELD_WIDTH - 11; i < GAME_FIELD_WIDTH - 2; i++)
            {
                engine.AddObject(new Wall(new Position(i, 7)));
            }

            for (int i = 0; i < 7; i++)
            {
                engine.AddObject(new Wall(new Position(GAME_FIELD_WIDTH - 11, i)));
            }

            Player player = Player.Instance;
            player.Position.X = 5;
            player.Position.Y = GAME_FIELD_HEIGHT - 5;

            engine.AddObject(new Zombie(new Position(2, GAME_FIELD_HEIGHT - 2), 100));
            engine.AddObject(new Zombie(new Position(23, GAME_FIELD_HEIGHT - 28), 100));
            engine.AddObject(new Zombie(new Position(38, 7), 100));

            engine.AddObject(new Zombie(new Position(58, 11), 100));

            engine.AddObject(new MedicKit(new Position(33, 6)));

            for (int i = 20; i < GAME_FIELD_WIDTH - 20; i++)
            {
                Wall newWall = new Wall(new Position(i, 10));
                engine.AddObject(newWall);
            }
            for (int i = GAME_FIELD_WIDTH; i > GAME_FIELD_WIDTH - 20; i--)
            {
                engine.AddObject(new Wall(new Position(i, GAME_FIELD_HEIGHT - 10)));
            }
            for (int i = GAME_FIELD_HEIGHT - 9; i < GAME_FIELD_HEIGHT - 3; i++)
            {
                engine.AddObject(new Wall(new Position(GAME_FIELD_WIDTH - 20, i)));
            }
            engine.AddObject(new Gate(new Position(GAME_FIELD_WIDTH - 5, 1)));
            engine.AddObject(new Key(new Position(GAME_FIELD_WIDTH - 2, GAME_FIELD_HEIGHT - 7)));
            engine.AddObject(new MedicKit(new Position(GAME_FIELD_WIDTH - 17, GAME_FIELD_HEIGHT - 7)));
            engine.AddObject(player);
        }
    }
}
