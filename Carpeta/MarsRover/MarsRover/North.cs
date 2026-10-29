namespace MarsRover;

public class North : Orientation
{
    public override string ToString() => "N";
    public override Coordinates Move(Coordinates from)
    {
        return from.Move(0, 1);
    }
}