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
}