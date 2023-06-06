using System.Numerics;
using CubeIntersection.Core.Domain.BaseObject;

namespace CubeIntersection.Core.Abstractions.Object3D
{
    public interface IObject3D : IHasVolume
    {
        Dimension3D Dimension { get; set; }
        Vector3 Position { get; set; }

        string ToString();
    }
}