using System.Numerics;

namespace CubeIntersection.Model
{
    public abstract class BoundaryObject3D : Object3D, IHasBoundary
    {
        public Boundary Boundary { get; } = new Boundary();

        public BoundaryObject3D(Vector3 position, Dimension3D dimension) : base(position, dimension)
        {
            Position = position;
            Dimension = dimension;
        }

        public BoundaryObject3D(float posX, float posY, float posZ,
            float length, float height, float width) :
                this(new Vector3(posX, posY, posZ),
                new Dimension3D(length, height, width))
        {
        }

        public abstract void CalculateBoundaries();
    }
}
