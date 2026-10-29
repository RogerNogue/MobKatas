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
        if (cardinality == "W")
            return new West();
        if (cardinality == "S")
            return new South();
        if (cardinality == "N")
            return new North();
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
            throw new NotImplementedException();
        }
        else if (cardinality.Equals("S"))
        {
            throw new NotImplementedException();
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}

public class North : Orientation
{
    public North() : base("N")
    {
    }

    public override Coordinates Move(Coordinates from)
    {
        return from.Move(0, 1);
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

public class South : Orientation
{
    public South() : base("S")
    {
    }

    public override Coordinates Move(Coordinates from)
    {
        return from.Move(0, -1);
    }
}

public class West : Orientation
{
    public West() : base("W")
    {
    }

    public override Coordinates Move(Coordinates from)
    {
        return from.Move(-1, 0);
    }
}