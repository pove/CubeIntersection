using CubeIntersection.Model;
using CubeIntersection.Collision;

namespace CubeIntersection.Test
{
    //[SetUpFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateCuboid()
        {
            Cuboid cube = new Cuboid(0, 0, 0, 4, 5, 6);

            Assert.That(cube.ToString(), Is.EqualTo("(0 0 0) (L:4 H:5 W:6)"));
        }

        [Test]
        public void CreateCube()
        {
            Cube cube = new Cube(0, 0, 0, 4);

            Assert.That(cube.ToString(), Is.EqualTo("(0 0 0) (L:4 H:4 W:4)"));
        }

        [Test]
        public void CalculateCubeVolume()
        {
            Cube cube = new Cube(0, 0, 0, 4);

            Assert.That(cube.Volume, Is.EqualTo(64));
        }

        [Test]
        public void CalculateCuboidVolume()
        {
            Cuboid cube = new Cuboid(0, 0, 0, 4, 5, 6);

            Assert.That(cube.Volume, Is.EqualTo(120));
        }

        [Test]
        public void CheckNoCollisionBetweenCubes()
        {
            Cube cube1 = new Cube(0, 0, 0, 4);
            Cube cube2 = new Cube(5, 0, 0, 6);

            CollisionDetector cd = new CollisionDetector(
                new ICollisionObject3D[] { cube1, cube2 });

            Assert.That(cd.CollisionDetected(), Is.False);
        }

        [Test]
        public void CheckCollisionBetweenCubes()
        {
            Cube cube1 = new Cube(0, 0, 0, 4);
            Cube cube2 = new Cube(2, 0, 4, 6);

            CollisionDetector cd = new CollisionDetector(
                new ICollisionObject3D[] { cube1, cube2 });

            Assert.That(cd.CollisionDetected(), Is.True);
        }

        [Test]
        public void ExtractCuboidBetweenCubesCollided()
        {
            Cube cube1 = new Cube(0, 0, 0, 4);
            Cube cube2 = new Cube(2, 0, 0, 6);

            CollisionDetector cd = new CollisionDetector(
                new ICollisionObject3D[] { cube1, cube2 });

            Assert.That(cd.ExtractCollisions()[0].ToString(), 
                Is.EqualTo("(0,5 0 0) (L:3 H:4 W:4)"));
        }

        [Test]
        public void VolumeBetweenCubesCollided()
        {
            Cube cube1 = new Cube(0, 0, 0, 4);
            Cube cube2 = new Cube(2, 0, 0, 6);

            CollisionDetector cd = new CollisionDetector(
                new ICollisionObject3D[] { cube1, cube2 });

            Assert.That(cd.ExtractCollisions()[0].Volume(), Is.EqualTo(48));
        }
    }
}