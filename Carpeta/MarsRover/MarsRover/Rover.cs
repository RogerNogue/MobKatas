namespace MarsRover;

public class Rover
{
    private readonly Coordinates coordinates;

    public Rover(Plateau plateau, Coordinates coordinates, Orientation orientation)
    {
        this.coordinates = coordinates;
    }

    public string Execute(string commands)
    {
        return $"{coordinates.X}:{coordinates.Y}:N";
    }
}