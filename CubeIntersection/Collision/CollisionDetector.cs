using CubeIntersection.Model;

namespace CubeIntersection.Collision
{
    public class CollisionDetector
    {
        private IList<ICollisionObject3D> Objects3D;

        public CollisionDetector(IList<ICollisionObject3D> objects3D)
        {
            Objects3D = objects3D;

            CalculateBoundaries();
        }

        private void CalculateBoundaries()
        {
            foreach (var object3D in Objects3D)
            {
                object3D.CalculateBoundaries();
            }
        }

        public bool CollisionDetected()
        {
            for (int i = 0; i < Objects3D.Count - 1; i++)
            {
                if (Objects3D[i].Collides(Objects3D[i + 1]))
                    return true;
            }

            return false;
        }

        public IList<ICollisionObject3D> ExtractCollisions()
        {
            IList<ICollisionObject3D> collisionObjects = new List<ICollisionObject3D>();

            for (int i = 0; i < Objects3D.Count - 1; i++)
            {
                if (!Objects3D[i].Collides(Objects3D[i + 1]))
                    continue;

                collisionObjects.Add(Objects3D[i].ExctractCollision(Objects3D[i + 1]));
            }

            return collisionObjects;
        }
    }
}