namespace Katas;

public static class RomanMatematician
{
    static Dictionary<int, RomanNumber> conversions = new Dictionary<int, RomanNumber>()
    {
        {1, RomanNumber.I},
        {2, RomanNumber.I.Concat(RomanNumber.I)},
        {3, RomanNumber.I.Concat(RomanNumber.I).Concat(RomanNumber.I)},
        {4, RomanNumber.I.Concat(RomanNumber.V)},
        {5, RomanNumber.V},
        {6, RomanNumber.V.Concat(RomanNumber.I)},
        {7, RomanNumber.V.Concat(RomanNumber.I).Concat(RomanNumber.I)},
        {8, RomanNumber.V.Concat(RomanNumber.I).Concat(RomanNumber.I).Concat(RomanNumber.I)},
        {9, RomanNumber.I.Concat(RomanNumber.X)},
        {10, RomanNumber.X}
    };
    
    public static RomanNumber Convert(int arabicNumber)
    {
        return conversions[arabicNumber];
    }
}