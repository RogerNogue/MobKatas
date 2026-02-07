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
    [Test]
    public void Convert1ShouldReturnI()
    {
        Assert.That(RomanMatematician.Convert(1), Is.EqualTo(I));
    }

    [Test]
    public void Convert2ShouldReturnII()
    {
        Assert.That(RomanMatematician.Convert(2), Is.EqualTo(I.Concat(I)));
    }

    [Test]
    public void Convert3ShouldReturnIII() 
    {
        Assert.That(RomanMatematician.Convert(3), Is.EqualTo(I.Concat(I).Concat(I)));    
    }

    [Test]
    public void Convert4ShouldReturnIV() {
        Assert.That(RomanMatematician.Convert(4), Is.EqualTo(I.Concat(V)));
    }
}

public static class RomanMatematician
{
    public static RomanNumber Convert(int arabicNumber)
    {
        if (arabicNumber == 4) {
            return I.Concat(V);
        }
        
        if (arabicNumber == 3) 
        {
            return I.Concat(I).Concat(I);
        }
        
        if (arabicNumber == 2)
        {
            return I.Concat(I);
        }

        if (arabicNumber == 1) {
            return I;
        }

        throw new NotImplementedException();
    }
}