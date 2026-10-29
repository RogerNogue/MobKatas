namespace MarsRover;

public class Rover
{
    private Coordinates coordinates;
    private Orientation orientation;

    public Rover(Plateau plateau, Coordinates coordinates, Orientation orientation)
    {
        this.coordinates = coordinates;
        this.orientation = orientation;
    }

    public string Execute(string commands)
    {
        if (commands == "M")
        {
            coordinates = orientation.Move(coordinates);
        }
        else if (commands == "MM") {
            coordinates = orientation.Move(coordinates);
            coordinates = orientation.Move(coordinates);
        }
        
        return $"{coordinates}:{orientation}";
    }
}
