using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassTheZombies.Common
{
    public static class CollisionDispatcher
    {
        public static void HandleCollisions(List<Zombie> movingObjects, List<GameObj> staticObjects)
        {
            HandleMovingWithStaticCollisions(movingObjects, staticObjects);
        }

        private static void HandleMovingWithStaticCollisions(List<Zombie> movingObjects, List<GameObj> staticObjects)
        {
            foreach (var movingObject in movingObjects)
            {
                int verticalIndex = VerticalCollisionIndex(movingObject, staticObjects);
                int horizontalIndex = HorizontalCollisionIndex(movingObject, staticObjects);

                Position movingCollisionForceDirection = new Position(0, 0);

                if (verticalIndex != -1)
                {
                    movingCollisionForceDirection.Y = -movingObject.Speed.Y;
                    staticObjects[verticalIndex].RespondToCollision(
                        new CollisionData(new Position(movingObject.Speed.Y, 0),
                            movingObject.GetCollisionGroupString())
                            );
                }

                if (horizontalIndex != -1)
                {
                    movingCollisionForceDirection.X = -movingObject.Speed.X;
                    staticObjects[horizontalIndex].RespondToCollision(
                        new CollisionData(new Position(0, movingObject.Speed.X),
                            movingObject.GetCollisionGroupString())
                            );
                }

                int diagonalIndex = -1;
                if (horizontalIndex == -1 && verticalIndex == -1)
                {
                    diagonalIndex = DiagonalCollisionIndex(movingObject, staticObjects);
                    if (diagonalIndex != -1)
                    {
                        movingCollisionForceDirection.Y = -movingObject.Speed.Y;
                        movingCollisionForceDirection.X = -movingObject.Speed.X;

                        staticObjects[diagonalIndex].RespondToCollision(
                        new CollisionData(new Position(movingObject.Speed.Y, 0),
                            movingObject.GetCollisionGroupString())
                            );
                    }
                }

                List<string> hitByMovingCollisionGroups = new List<string>();

                if (verticalIndex != -1)
                {
                    hitByMovingCollisionGroups.Add(staticObjects[verticalIndex].GetCollisionGroupString());
                }

                if (horizontalIndex != -1)
                {
                    hitByMovingCollisionGroups.Add(staticObjects[horizontalIndex].GetCollisionGroupString());
                }

                if (diagonalIndex != -1)
                {
                    hitByMovingCollisionGroups.Add(staticObjects[diagonalIndex].GetCollisionGroupString());
                }

                if (verticalIndex != -1 || horizontalIndex != -1 || diagonalIndex != -1)
                {
                    movingObject.RespondToCollision(
                        new CollisionData(movingCollisionForceDirection,
                            hitByMovingCollisionGroups)
                            );
                }
            }
        }

        public static int VerticalCollisionIndex(Zombie moving, List<GameObj> objects)
        {
            List<Position> profile = moving.GetCollisionProfile();

            List<Position> verticalProfile = new List<Position>();

            foreach (var coord in profile)
            {
                verticalProfile.Add(new Position(coord.Y + moving.Speed.Y, coord.X));
            }

            int collisionIndex = GetCollisionIndex(moving, objects, verticalProfile);

            return collisionIndex;
        }

        public static int HorizontalCollisionIndex(Zombie moving, List<GameObj> objects)
        {
            List<Position> profile = moving.GetCollisionProfile();

            List<Position> horizontalProfile = new List<Position>();

            foreach (var coord in profile)
            {
                horizontalProfile.Add(new Position(coord.Y, coord.X + moving.Speed.X));
            }

            int collisionIndex = GetCollisionIndex(moving, objects, horizontalProfile);

            return collisionIndex;
        }

        public static int DiagonalCollisionIndex(Zombie moving, List<GameObj> objects)
        {
            List<Position> profile = moving.GetCollisionProfile();

            List<Position> horizontalProfile = new List<Position>();

            foreach (var coord in profile)
            {
                horizontalProfile.Add(new Position(coord.Y + moving.Speed.Y, coord.X + moving.Speed.X));
            }

            int collisionIndex = GetCollisionIndex(moving, objects, horizontalProfile);

            return collisionIndex;
        }

        private static int GetCollisionIndex(Zombie moving, ICollection<GameObj> objects, List<Position> movingProfile)
        {
            int collisionIndex = 0;

            foreach (var obj in objects)
            {
                if (moving.CanCollideWith(obj.GetCollisionGroupString()) || obj.CanCollideWith(moving.GetCollisionGroupString()))
                {
                    List<Position> objProfile = obj.GetCollisionProfile();

                    if (ProfilesIntersect(movingProfile, objProfile))
                    {
                        return collisionIndex;
                    }
                }

                collisionIndex++;
            }

            return -1;
        }

        private static bool ProfilesIntersect(List<Position> firstProfile, List<Position> secondProfile)
        {
            foreach (var firstCoord in firstProfile)
            {
                foreach (var secondCoord in secondProfile)
                {
                    if (firstCoord.Equals(secondCoord))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
