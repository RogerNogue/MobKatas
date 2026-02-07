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

    [Test]
    public void Convert5ShouldReturnV() {
        Assert.That(RomanMatematician.Convert(5), Is.EqualTo(V));
    }

    [Test]
    public void Convert6ShouldReturnVI()
    {
        Assert.That(RomanMatematician.Convert(6), Is.EqualTo(V.Concat(I)));
    }

    [Test]
    public void Convert7ShouldReturnVII()
    {
        Assert.That(RomanMatematician.Convert(7), Is.EqualTo(V.Concat(I).Concat(I)));
    }

    [Test]
    public void Convert8ShouldReturnVIII()
    {
        Assert.That(RomanMatematician.Convert(8), Is.EqualTo(V.Concat(I).Concat(I).Concat(I)));
    }

    [Test]
    public void Convert9ShouldReturnIX()
    {
        Assert.That(RomanMatematician.Convert(9), Is.EqualTo(I.Concat(X)));
    }

    [Test]
    public void Convert10ShouldReturnX()
    {
        Assert.That(RomanMatematician.Convert(10), Is.EqualTo(X));
    }
}

public static class RomanMatematician
{
    public static RomanNumber Convert(int arabicNumber)
    {
        if (arabicNumber == 1) {
            return I;
        }
        
        if (arabicNumber == 2)
        {
            return I.Concat(I);
        }
        
        if (arabicNumber == 3) 
        {
            return I.Concat(I).Concat(I);
        }
        
        if (arabicNumber == 4) {
            return I.Concat(V);
        }
        
        if (arabicNumber == 5) {
            return V;
        }
        
        if (arabicNumber == 6) {
            return V.Concat(I);
        }
        
        if (arabicNumber == 7) {
            return V.Concat(I).Concat(I);
        }
        
        if (arabicNumber == 8) {
            return V.Concat(I).Concat(I).Concat(I);
        }
        
        if (arabicNumber == 9) {
            return I.Concat(X);
        }
        
        if (arabicNumber == 10) {
            return X;
        }

        throw new NotImplementedException();
    }
}