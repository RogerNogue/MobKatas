namespace MarsRover;

public class Orientation
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
        if (cardinality.Equals("E"))
        {
            return from.Move(1, 0);
        }
        else if (cardinality.Equals("W"))
        {
            return from.Move(-1, 0);
        }
        else if (cardinality.Equals("S"))
        {
            return from.Move(0, -1);
        }
        else
        {
            return from.Move(0, 1);
        }
    }
}