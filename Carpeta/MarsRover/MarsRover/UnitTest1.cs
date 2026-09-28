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
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}