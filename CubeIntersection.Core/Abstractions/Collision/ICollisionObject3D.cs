using CubeIntersection.Core.Abstractions.Boundary;
using CubeIntersection.Core.Abstractions.Object3D;

namespace CubeIntersection.Core.Abstractions.Collision
{
    public interface ICollisionObject3D : IObject3D, IHasBoundary
    {
        public bool Collides(ICollisionObject3D otherCollisionObject);

        public abstract ICollisionObject3D ExctractCollision(ICollisionObject3D otherCollisionObject);
    }
}