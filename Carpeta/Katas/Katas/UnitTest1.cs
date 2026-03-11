using static Katas.RomanNumber;

namespace Katas;

/*
 *
Number	Numeral
1	I
5	V
10	X
50	L
100	C
500	D
1000 M


Number	Numeral
1	    I
2	    II
3	    III
4	    IV

 */

// TODO
// - Precondition of invalid roman numbers concatenation

public class Tests
{
    static List<(int arabic, RomanNumber expectedConversion)> testCases = new() {
        (1, I),
        (2, I.Concat(I)),
        (3, I.Concat(I).Concat(I)),
        (4, I.Concat(V)),
        (5, V),
        (6, V.Concat(I)),
        (7, V.Concat(I).Concat(I)),
        (8, V.Concat(I).Concat(I).Concat(I)),
        (9, I.Concat(X)),
        (10, X)
    };

    [TestCaseSource(nameof(testCases))]
    public void ConvertArabicToRoman((int arabic, RomanNumber expected) testCase) {
        Assert.That(RomanMatematician.Convert(testCase.arabic), Is.EqualTo(testCase.expected));
    }
}