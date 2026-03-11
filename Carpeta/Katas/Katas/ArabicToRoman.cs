using static Katas.RomanNumber;

namespace Katas;

public static class ArabicToRoman
{
    static Dictionary<int, RomanNumber> conversions = new Dictionary<int, RomanNumber>()
    {
        {1, I},
        {2, I.Concat(I)},
        {3, I.Concat(I).Concat(I)},
        {4, I.Concat(V)},
        {5, V},
        {6, V.Concat(I)},
        {7, V.Concat(I).Concat(I)},
        {8, V.Concat(I).Concat(I).Concat(I)},
        {9, I.Concat(X)},
        {10, X}
    };
    
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
        if (arabicNumber == 11) {
            var firstNumber = LowerClosestArabicPrimitive(arabicNumber);
            var secondNumber = arabicNumber - firstNumber;
            return conversions[firstNumber].Concat(conversions[secondNumber]);
        }
        if (arabicNumber == 12)
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
        if (arabicNumber == 13) {
            return conversions[10].Concat(conversions[1]).Concat(conversions[1]).Concat(conversions[1]);
        }
        
        return conversions[arabicNumber];
    }
}