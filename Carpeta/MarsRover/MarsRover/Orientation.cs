namespace MarsRover;

public abstract class Orientation
{
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
        throw new ArgumentException("Invalid cardinality");
    }
    
    public abstract Coordinates Move(Coordinates from);
}

public class North : Orientation
{
    public override string ToString() => "N";
    public override Coordinates Move(Coordinates from)
    {
        return from.Move(0, 1);
    }
}

public class East : Orientation
{
    public override string ToString() => "E";
    public override Coordinates Move(Coordinates from)
    {
        return from.Move(1, 0);
    }
}

public class South : Orientation
{
    public override string ToString() => "S";
    public override Coordinates Move(Coordinates from)
    {
        return from.Move(0, -1);
    }
}

public class West : Orientation
{
    public override string ToString() => "W";
    public override Coordinates Move(Coordinates from)
    {
        return from.Move(-1, 0);
    }
}