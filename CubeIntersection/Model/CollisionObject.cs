using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CubeIntersection.Model3D
{
    public class CollisionObject : Object3D, IHasVolume
    {
        public CollisionObject(Vector3 position, Dimension3D dimension) : 
            base(position, dimension)
        {
        }

        public CollisionObject(float posX, float posY, float posZ,
            float length, float height, float width) : 
            base(posX, posY, posZ, length, height, width)
        {
        }

        public float Volume()
        {
            return CuboidVolume(Dimension);
        }

        private float CuboidVolume(Dimension3D dimension)
        {
            return dimension.Length
                * dimension.Width
                * dimension.Height;
        }
    }
}
