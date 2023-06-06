using CubeIntersection.Core.Domain.Boundaries;

namespace CubeIntersection.Core.Abstractions.Boundary
{
    public interface IHasBoundary
    {
        public Boundary3D Boundary { get; }

        abstract void CalculateBoundaries();
    }
}
