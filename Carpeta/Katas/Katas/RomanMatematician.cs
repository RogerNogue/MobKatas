using static Katas.RomanNumber;

namespace Katas;

public static class RomanMatematician
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
    
    public static RomanNumber Convert(int arabicNumber)
    {
        return conversions[arabicNumber];
    }
}