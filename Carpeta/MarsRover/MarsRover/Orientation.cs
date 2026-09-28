namespace MarsRover;

public struct Orientation
{
    private readonly string cardinality;

    Orientation(string cardinality)
    {
        this.cardinality = cardinality;
    }
    
    public static Orientation North => new Orientation("N");
    public static Orientation South => new Orientation("S");

    public override string ToString() => cardinality;
}