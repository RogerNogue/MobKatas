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
}