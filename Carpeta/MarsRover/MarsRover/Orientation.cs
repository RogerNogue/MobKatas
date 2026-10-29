namespace MarsRover;

public class Orientation
{
    private readonly string cardinality;

    protected Orientation(string cardinality)
    {
        this.cardinality = cardinality;
    }

    public override string ToString() => cardinality;

    public static Orientation CreateInstance(string cardinality)
    {
        if (cardinality == "E")
            return new East();
        return new Orientation(cardinality);
    }
    
    virtual public Coordinates Move(Coordinates from)
    {
        if (cardinality.Equals("E"))
        {
            throw new NotImplementedException();
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

public class East : Orientation
{
    public East() : base("E")
    {
    }

    public override Coordinates Move(Coordinates from)
    {
        return from.Move(1, 0);
    }
}