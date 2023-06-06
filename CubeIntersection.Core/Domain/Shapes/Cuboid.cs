using CubeIntersection.Core.Abstractions.Collision;
using CubeIntersection.Core.Application.Collision;
using CubeIntersection.Core.Domain.BaseObject;
using CubeIntersection.Core.Domain.Boundaries;
using System.Numerics;

namespace CubeIntersection.Core.Domain.Shapes
{
    public class Cuboid : BoundaryObject3D, ICollisionObject3D
    {
        public Cuboid(Vector3 position, Dimension3D dimension) : base(position, dimension)
        {
        }

        public Cuboid(float posX, float posY, float posZ,
            float length, float height, float width)
            : base(posX, posY, posZ, length, height, width)
        {
        }

        public override void CalculateBoundaries()
        {
            Boundary.Left = Position.X - Dimension.Length / 2f;
            Boundary.Right = Position.X + Dimension.Length / 2f;
            Boundary.Bottom = Position.Y - Dimension.Height / 2f;
            Boundary.Top = Position.Y + Dimension.Height / 2f;
            Boundary.Behind = Position.Z - Dimension.Length / 2f;
            Boundary.Front = Position.Z + Dimension.Length / 2f;
        }

        public override float Volume()
        {
            return Dimension.Length
                * Dimension.Width
                * Dimension.Height;
        }

        public bool Collides(ICollisionObject3D otherCollisionObject)
        {
            return BoundaryCollision.Collides(Boundary, otherCollisionObject.Boundary);
        }

        public ICollisionObject3D ExctractCollision(ICollisionObject3D otherCollisionObject)
        {
            Boundary3D boundary = BoundaryCollision.ExtractCollision(
                   Boundary, otherCollisionObject.Boundary);

            Dimension3D dimension = new Dimension3D()
            {
                Length = boundary.Right - boundary.Left,
                Height = boundary.Top - boundary.Bottom,
                Width = boundary.Front - boundary.Behind
            };

            Vector3 position = new Vector3(
                boundary.Left + dimension.Length / 2f,
                boundary.Bottom + dimension.Height / 2f,
                boundary.Behind + dimension.Width / 2f);

            return new Cuboid(position, dimension);
        }
    }
}
