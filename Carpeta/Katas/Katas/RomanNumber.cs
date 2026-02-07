namespace Katas;

public readonly struct RomanNumber
{
    private readonly string value;

    RomanNumber(string value)
    {
        this.value = value;
    }

    public RomanNumber Concat(RomanNumber other)
    {
        return new RomanNumber(value + other.value);
    }
    
    public override string ToString() {
        return value;
    }

    public static readonly RomanNumber I = new RomanNumber("I");
    public static readonly RomanNumber V = new RomanNumber("V");
}