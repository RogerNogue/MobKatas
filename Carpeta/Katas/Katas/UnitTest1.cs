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
        Assert.That(RomanMatematician.Convert(1), Is.EqualTo("I"));
    }
}

public static class RomanMatematician
{
    public static string Convert(int arabicNumber)
    {
        return "I";
    }
}