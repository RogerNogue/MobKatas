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

    public static RomanNumber I => new RomanNumber("I");
}