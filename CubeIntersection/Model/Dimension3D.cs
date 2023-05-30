
namespace CubeIntersection.Model
{
    public struct Dimension3D
    {
        public Dimension3D(float length, float height, float width) 
        {
            Length = length;
            Height = height;
            Width = width;
        }
        public Dimension3D(float value) : this(value, value, value)
        {
        }

        /// <summary>
        /// x dimension
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// y dimension
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// z dimension
        /// </summary>
        public float Width { get; set; }

        public override string ToString()
        {
            return $"(L:{Length} H:{Height} W:{Width})";
        }
    }
}
