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
            if (Objects3D.Count < 2)
                return false;

            for (int i = 0; i < Objects3D.Count - 1; i++)
            {
                for (int j = i + 1; j < Objects3D.Count; j++)
                {
                    if (Objects3D[i].Collides(Objects3D[j]))
                        return true;
                }
            }

            return false;
        }

        public IList<ICollisionObject3D> ExtractCollisions()
        {
            IList<ICollisionObject3D> collisionObjects = new List<ICollisionObject3D>();

            if (Objects3D.Count < 2)
                return collisionObjects;

            for (int i = 0; i < Objects3D.Count - 1; i++)
            {
                for (int j = i + 1; j < Objects3D.Count; j++)
                {
                    if (!Objects3D[i].Collides(Objects3D[j]))
                        continue;

                    collisionObjects.Add(Objects3D[i].ExctractCollision(Objects3D[j]));
                }
            }

            return collisionObjects;
        }
    }
}