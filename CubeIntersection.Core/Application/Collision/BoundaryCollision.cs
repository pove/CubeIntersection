using CubeIntersection.Core.Domain.Boundaries;

namespace CubeIntersection.Core.Application.Collision
{
    public static class BoundaryCollision
    {
        public static bool Collides(Boundary3D bound1, Boundary3D bound2)
        {
            return bound1.Left < bound2.Right
                && bound1.Right > bound2.Left
                && bound1.Bottom < bound2.Top
                && bound1.Top > bound2.Bottom
                && bound1.Behind < bound2.Front
                && bound1.Front > bound2.Behind;
        }

        public static Boundary3D ExtractCollision(Boundary3D bound1, Boundary3D bound2)
        {
            Boundary3D collision = new Boundary3D();

            collision.Left = Math.Max(bound1.Left, bound2.Left);
            collision.Right = Math.Min(bound1.Right, bound2.Right);
            collision.Bottom = Math.Max(bound1.Bottom, bound2.Bottom);
            collision.Top = Math.Min(bound1.Top, bound2.Top);
            collision.Behind = Math.Max(bound1.Behind, bound2.Behind);
            collision.Front = Math.Min(bound1.Front, bound2.Front);

            return collision;
        }
    }
}
