using CubeIntersection.Core.Domain.BaseObject;
using System.Numerics;

namespace CubeIntersection.Core.Domain.Shapes
{
    public class Cube : Cuboid
    {
        public Cube(Vector3 position, float dimension) :
            base(position, new Dimension3D(dimension))
        {
        }

        public Cube(float posX, float posY, float posZ, float dimension) :
            base(posX, posY, posZ, dimension, dimension, dimension)
        {
        }
    }
}
