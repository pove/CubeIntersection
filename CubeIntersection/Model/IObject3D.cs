using System.Numerics;

namespace CubeIntersection.Model
{
    public interface IObject3D: IHasVolume
    {
        Dimension3D Dimension { get; set; }
        Vector3 Position { get; set; }

        string ToString();
    }
}