using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CubeIntersection.Model;

namespace CubeIntersection.Model
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
