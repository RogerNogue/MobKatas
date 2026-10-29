namespace MarsRover;

public class West : Orientation
{
    public override string ToString() => "W";
    public override Coordinates Move(Coordinates from)
    {
        return from.Move(-1, 0);
    }
}