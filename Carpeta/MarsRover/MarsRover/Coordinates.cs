namespace MarsRover;

public struct Coordinates
{
    readonly int X;
    readonly int Y;

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{X}:{Y}";
    }

    public Coordinates Move(int deltaX, int deltaY)
    {
        return new Coordinates(X + deltaX, Y + deltaY);
    }
}