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
            Coordinates newPosition = coordinates;
            if (orientation.Equals(Orientation.CreateInstance("E")))
            {
                newPosition = coordinates.Move(1, 0); 
            }
            else
            {
                newPosition = coordinates.Move(0, 1);
            }
            return $"{newPosition}:{orientation}";   
        }
        return $"{coordinates}:{orientation}";
    }
}
