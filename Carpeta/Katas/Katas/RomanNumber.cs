namespace Katas;

public struct RomanNumber
{
    private readonly string value;

    public RomanNumber(string value)
    {
        this.value = value;
    }

    public RomanNumber Concat(RomanNumber other)
    {
        return new RomanNumber(value + other.value);
    }

    public static RomanNumber I => new RomanNumber("I");
}