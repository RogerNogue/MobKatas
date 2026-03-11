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
    
    public static RomanNumber Convert(int arabicNumber)
    {
        //alternative: dictionary lookup instead of comparison
        if (arabicNumber == 0)
        {
            return Nothing;
        }
        var closestNumber = LowerClosestArabicPrimitive(arabicNumber);
        return primitives[closestNumber].Concat(Convert(arabicNumber - closestNumber));
    }
    
    private static int LowerClosestArabicPrimitive(int arabicNumber) {
        return primitives.Keys.Last(x => x <= arabicNumber);
    }
}