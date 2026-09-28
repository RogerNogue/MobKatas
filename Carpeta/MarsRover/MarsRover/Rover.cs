namespace MarsRover;

public class Rover
{
    private readonly Coordinates coordinates;
    private readonly Orientation orientation;

    public Rover(Plateau plateau, Coordinates coordinates, Orientation orientation)
    {
        this.coordinates = coordinates;
        this.orientation = orientation;
    }

    public string Execute(string commands)
    {
        return $"{coordinates.X}:{coordinates.Y}:{orientation}";
    }
}