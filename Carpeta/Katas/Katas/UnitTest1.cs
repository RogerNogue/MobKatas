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
    public void Test1()
    {
        var sut = new RomanMatematician();

        var conversion = sut.Convert(1);
        
        Assert.AreEqual("I", conversion);
    }
}

public class RomanMatematician
{
    public string Convert(int i)
    {
        return "I";
    }
}