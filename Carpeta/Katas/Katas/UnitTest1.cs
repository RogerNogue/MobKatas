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