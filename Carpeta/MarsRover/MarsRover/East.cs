namespace MarsRover;

public class East : Orientation
{
    public override string ToString() => "E";
    public override Coordinates Move(Coordinates from)
    {
        return from.Move(1, 0);
    }
}