namespace MarsRover;

public class South : Orientation
{
    public override string ToString() => "S";
    public override Coordinates Move(Coordinates from)
    {
        return from.Move(0, -1);
    }
}