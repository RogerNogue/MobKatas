namespace MarsRover;

/*
[x] State: (x, y, q), Commands: "" => x:y:q
[x] State: (0, 0, N), Commands: "M" => 0:1:N
[x] State: (0, 0, E), Commands: "M" => 1:0:E
[] State: (1, 1, W), Commands: "M" => 0:1:W
[] State: (1, 1, S), Commands: "M" => 1:0:S
[] State: (0, 0, N), Commands: "MM" => 0:2:N
[] State: (0, 0, N), Commands: "M" "M" => 0:2:N
[] State: (0, 0, N), Commands: "R" => 0:0:E
[] State: (0, 0, E), Commands: "R" => 0:0:S
[] State: (0, 0, S), Commands: "R" => 0:0:W
[] State: (0, 0, W), Commands: "R" => 0:0:N
[] State: (0, 0, N), Commands: "L" => 0:0:W
[] State: (0, 0, W), Commands: "L" => 0:0:S
[] State: (0, 0, S), Commands: "L" => 0:0:E
[] State: (0, 0, E), Commands: "L" => 0:0:N
[] State: (0, 0, S), Commands: "M" => 0:9:S
[] State: (0, 0, W), Commands: "M" => 9:0:W
[] State: (9, 9, N), Commands: "M" => 9:0:N
[] State: (9, 9, E), Commands: "M" => 0:9:E

Juntar position and rotation en una misma struct?
 */
public class Tests
{
    [TestCase(0, 0, "N", "0:0:N")]
    [TestCase(1, 1, "N", "1:1:N")]
    [TestCase(0, 0, "S", "0:0:S")]
    public void Execute_ReturnsStateOfRover(int x, int y, string orientation, string expected)
    {
        var sut = new Rover(new Plateau(10, 10), new Coordinates(x, y), Orientation.CreateInstance(orientation));

        var result = sut.Execute("");
        
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0, 0, "N", "0:1:N")]
    [TestCase(0, 0, "E", "1:0:E")]
    public void Execute_MovesForward(int x, int y, string orientation, string expected)
    {
        var sut = new Rover(new Plateau(10, 10), new Coordinates(x, y), Orientation.CreateInstance(orientation));

        var result = sut.Execute("M");
        
        Assert.That(result, Is.EqualTo(expected));
    }
}