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
        if (commands == "M")
        {
            if (orientation.Equals(Orientation.CreateInstance("E")))
            {
                return $"{coordinates.Move(1, 0)}:{orientation}";
            }
            return $"{coordinates.Move(0, 1)}:{orientation}";   
        }
        return $"{coordinates}:{orientation}";
    }
}
