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