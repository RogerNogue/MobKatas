using static Katas.RomanNumber;

namespace Katas;

public static class ArabicToRoman
{
    static Dictionary<int, RomanNumber> primitives = new Dictionary<int, RomanNumber>()
    {
        {1, I},
        {4, I.Concat(V)},
        {5, V},
        {9, I.Concat(X)},
        {10, X}
    };

    private static int LowerClosestArabicPrimitive(int arabicNumber) {
        return primitives.Keys.Last(x => x <= arabicNumber);
    }
    
    public static RomanNumber Convert(int arabicNumber)
    {
        var result = string.Empty;
        while (arabicNumber > 0)
        {
            var closestNumber = LowerClosestArabicPrimitive(arabicNumber);
            arabicNumber -= closestNumber;
            result = result + primitives[closestNumber];
        }
        return new RomanNumber(result);
    }
}