using CubeIntersection.Core.Domain.Shapes;
using CubeIntersection.Application.Collision;

Console.WriteLine("Enter number of cubes:");

if (!int.TryParse(Console.ReadLine(), out int number))
{
    Console.WriteLine("Only integers allowed");
    return;
}

Console.WriteLine("Enter center position and dimensions for each cube");
Console.WriteLine("The pattern shoud be: positionX, positionY, positionZ, dimension");
Console.WriteLine("Example 1: 0, 0, 0, 4");
Console.WriteLine("Example 2: 0.5 0 0 6");
List<Cube> cubes = new List<Cube>();
while (cubes.Count < number)
{
    string? line = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(line))
    {
        Console.WriteLine("Please enter cube properties");
        continue;
    }

    string[] sparts = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

    if (sparts.Length != 4)
    {
        Console.WriteLine("Four numbers are needed for each cube");
        continue;
    }

    float[] fparts = new float[sparts.Length];
    try
    {
        fparts = Array.ConvertAll(sparts, float.Parse);
    }
    catch (FormatException)
    {
        Console.WriteLine("Only numbers allowed");
        continue;
    }

    cubes.Add(new Cube(fparts[0], fparts[1], fparts[2], fparts[3]));
}

CollisionDetector cd = new CollisionDetector(cubes.ToArray());

if (cd.CollisionDetected())
{
    Console.WriteLine("Collision detected between the cubes!");
}
else
{
    Console.WriteLine("There is no collision between the cubes!");
    return;
}

Console.WriteLine("Volumes of the collisions:");
int count = 0;
foreach (var collisionObject in cd.ExtractCollisions())
{
    Console.WriteLine(++count + " -> " + collisionObject.Volume());
}