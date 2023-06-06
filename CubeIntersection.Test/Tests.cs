using CubeIntersection.Application.Collision;
using CubeIntersection.Core.Abstractions.Collision;
using CubeIntersection.Core.Domain.Shapes;

namespace CubeIntersection.Test
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private enum TestParameter { Cube1, Cube2, CuboidString, Volume };

        private static IEnumerable<TestCaseData> CubesNotCollide()
        {
            yield return new TestCaseData(new Cube(0, 0, 0, 4), new Cube(5, 0, 0, 6));
            yield return new TestCaseData(new Cube(-3, -6, -10, 10), new Cube(8, 5, 12, 6));
        }

        private static IEnumerable<TestCaseData> CubesCollideWithCuboidAndVolume()
        {
            yield return new TestCaseData(new Cube(0, 0, 0, 4), new Cube(2, 0, 4, 6), "(0,5 0 1,5) (L:3 H:4 W:1)", 12);
            yield return new TestCaseData(new Cube(10, 10, 10, 10), new Cube(5, 5, 5, 5), "(6,25 6,25 6,25) (L:2,5 H:2,5 W:2,5)", 15.625f);
            yield return new TestCaseData(new Cube(100, 100, 100, 50), new Cube(120, 120, 120, 20), "(117,5 117,5 117,5) (L:15 H:15 W:15)", 3375);
            yield return new TestCaseData(new Cube(-3, -6, -10, 10), new Cube(-5, -10, -8, 15), "(-3 -6,75 -10) (L:10 H:8,5 W:10)", 850);
        }

        private static IEnumerable<TestCaseData> CubesCollide()
        {
            foreach (var item in CubesCollideWithCuboidAndVolume())
            {
                yield return new TestCaseData(
                    item.Arguments[(int)TestParameter.Cube1],
                    item.Arguments[(int)TestParameter.Cube2]);
            }
        }

        private static IEnumerable<TestCaseData> CubesCollideWithCuboid()
        {
            foreach (var item in CubesCollideWithCuboidAndVolume())
            {
                yield return new TestCaseData(
                    item.Arguments[(int)TestParameter.Cube1],
                    item.Arguments[(int)TestParameter.Cube2],
                    item.Arguments[(int)TestParameter.CuboidString]);
            }
        }

        private static IEnumerable<TestCaseData> CubesCollideWithVolume()
        {
            foreach (var item in CubesCollideWithCuboidAndVolume())
            {
                yield return new TestCaseData(
                    item.Arguments[(int)TestParameter.Cube1],
                    item.Arguments[(int)TestParameter.Cube2],
                    item.Arguments[(int)TestParameter.Volume]);
            }
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

        [Test, TestCaseSource(nameof(CubesNotCollide))]
        public void CheckNoCollisionBetweenCubes(Cube cube1, Cube cube2)
        {
            CollisionDetector cd = new CollisionDetector(
                new ICollisionObject3D[] { cube1, cube2 });

            Assert.That(cd.CollisionDetected(), Is.False);
        }

        [Test, TestCaseSource(nameof(CubesCollide))]
        public void CheckCollisionBetweenCubes(Cube cube1, Cube cube2)
        {

            CollisionDetector cd = new CollisionDetector(
                new ICollisionObject3D[] { cube1, cube2 });

            Assert.That(cd.CollisionDetected(), Is.True);
        }

        [Test, TestCaseSource(nameof(CubesCollideWithCuboid))]
        public void ExtractCuboidBetweenCubesCollided(Cube cube1, Cube cube2, string cuboidstring)
        {
            CollisionDetector cd = new CollisionDetector(
                new ICollisionObject3D[] { cube1, cube2 });

            Assert.That(cd.ExtractCollisions()[0].ToString(), 
                Is.EqualTo(cuboidstring));
        }

        [Test, TestCaseSource(nameof(CubesCollideWithVolume))]
        public void VolumeBetweenCubesCollided(Cube cube1, Cube cube2, float volume)
        {
            CollisionDetector cd = new CollisionDetector(
                new ICollisionObject3D[] { cube1, cube2 });

            Assert.That(cd.ExtractCollisions()[0].Volume(), Is.EqualTo(volume));
        }

        [Test]
        public void CheckCollisionBetweenAlternatedCubes()
        {
            Cube cube1 = new Cube(10, 0, 0, 4);
            Cube cube2 = new Cube(-10, 0, 0, 6);
            Cube cube3 = new Cube(11, 0, 0, 5);

            CollisionDetector cd = new CollisionDetector(
                new ICollisionObject3D[] { cube1, cube2, cube3 });

            Assert.That(cd.CollisionDetected(), Is.True);
        }
    }
}