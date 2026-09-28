using NUnit.Framework.Constraints;

namespace MarsRover;

/*
State: (x, y, q), Commands: "" => x:y:q

State: (0, 0, N), Commands: "M" => 0:1:N
State: (0, 0, E), Commands: "M" => 1:0:E
State: (1, 1, W), Commands: "M" => 0:1:W
State: (1, 1, S), Commands: "M" => 1:0:S
State: (0, 0, N), Commands: "MM" => 0:2:N
State: (0, 0, N), Commands: "M" "M" => 0:2:N
State: (0, 0, N), Commands: "R" => 0:0:E
State: (0, 0, E), Commands: "R" => 0:0:S
State: (0, 0, S), Commands: "R" => 0:0:W
State: (0, 0, W), Commands: "R" => 0:0:N
State: (0, 0, N), Commands: "L" => 0:0:W
State: (0, 0, W), Commands: "L" => 0:0:S
State: (0, 0, S), Commands: "L" => 0:0:E
State: (0, 0, E), Commands: "L" => 0:0:N
State: (0, 0, S), Commands: "M" => 0:9:S
State: (0, 0, W), Commands: "M" => 9:0:W
State: (9, 9, N), Commands: "M" => 9:0:N
State: (9, 9, E), Commands: "M" => 0:9:E
 */
public class Tests
{
    [Test]
    public void Execute_ReturnsStateOfRover()
    {
        var sut = new Rover(new Plateau(10, 10), new Coordinates(0, 0), Orientation.North);

        var result = sut.Execute("");
        
        Assert.That(result, Is.EqualTo("0:0:N"));
    }
}

public struct Orientation
{
    public static Orientation North { get; set; }
}

public struct Coordinates
{
    public Coordinates(int x, int y)
    {
        
    }
}

public class Plateau
{
    public Plateau(int width, int height)
    {
        
    }
}

public class Rover
{
    public Rover(Plateau plateau, Coordinates coordinates, Orientation north)
    {
        
    }

    public string Execute(string commands)
    {
        return "0:0:N";
    }
}