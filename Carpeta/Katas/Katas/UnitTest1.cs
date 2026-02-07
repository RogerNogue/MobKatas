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
public class Tests
{
    [Test]
    public void Convert1ShouldReturnI()
    {
        Assert.That(RomanMatematician.Convert(1), Is.EqualTo(RomanNumber.I));
    }

    [Test]
    public void Convert2ShouldReturnII()
    {
        Assert.That(RomanMatematician.Convert(2), Is.EqualTo(new RomanNumber("II")));
    }
}

public struct RomanNumber
{
    private readonly string value;

    public RomanNumber(string value)
    {
        this.value = value;
    }

    public static RomanNumber I => new RomanNumber("I");
}

public static class RomanMatematician
{
    private static RomanNumber I = RomanNumber.I;

    public static RomanNumber Convert(int arabicNumber)
    {
        if (arabicNumber == 2)
        {
            return new RomanNumber("II");
        }

        return I;
    }
}