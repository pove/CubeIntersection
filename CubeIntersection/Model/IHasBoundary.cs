
namespace CubeIntersection.Model
{
    public interface IHasBoundary
    {
        public Boundary Boundary { get; }

        abstract void CalculateBoundaries();
    }
}
