using System.Numerics;
using CubeIntersection.Core.Abstractions.Object3D;

namespace CubeIntersection.Core.Domain.BaseObject
{
    public abstract class Object3D : IObject3D
    {
        public Vector3 Position { get; set; } = new Vector3();

        public Dimension3D Dimension { get; set; } = new Dimension3D();

        public Object3D(Vector3 position, Dimension3D dimension)
        {
            Position = position;
            Dimension = dimension;
        }

        public Object3D(float posX, float posY, float posZ,
            float length, float height, float width) :
                this(new Vector3(posX, posY, posZ),
                new Dimension3D(length, height, width))
        {
        }

        public abstract float Volume();

        public override string ToString()
        {
            return
                $"({Position.X} {Position.Y} {Position.Z}) "
                + Dimension.ToString();
        }
    }
}
