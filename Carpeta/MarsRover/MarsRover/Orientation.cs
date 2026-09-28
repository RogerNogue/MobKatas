namespace MarsRover;

public struct Orientation
{
    private readonly string cardinality;

    private Orientation(string cardinality)
    {
        this.cardinality = cardinality;
    }

    public override string ToString() => cardinality;

    public static Orientation CreateInstance(string cardinality)
    {
        return new Orientation(cardinality);
    }

    public Coordinates Move(Coordinates from)
    {
        if (this.Equals(Orientation.CreateInstance("E")))
        {
            return from.Move(1, 0); 
        }
        else
        {
            return from.Move(0, 1);
        }
    }
}