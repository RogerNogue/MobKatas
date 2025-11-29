namespace LeapYear;


/*
       A year is not a leap year if not divisible by 4
       A year is a leap year if divisible by 4
       A year is a leap year if divisible by 400
       A year is not a leap year if divisible by 100 but not by 400
   Examples:
       1997 is not a leap year (not divisible by 4)
       1996 is a leap year (divisible by 4)
       1600 is a leap year (divisible by 400)
       1800 is not a leap year (divisible by 4, divisible by 100, NOT divisible by 400)
 * 
 */




public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void YearNotLeapIfNotDivisibleBy4()
    {
        Year sut = new Year(3);

        Assert.False(sut.IsLeap());
    }

    [Test]
    public void YearIsLeapIfDivisibleBy4()
    {
        Year sut = new Year(4);

        Assert.True(sut.IsLeap());
    }

    [Test]
    public void YearIsLeapIfDivisibleBy400()
    {
        Year sut = new Year(400);
        Assert.True(sut.IsLeap());
    }

    [Test]
    public void YearIsNotLeapIfDivisibleBy100ButNot400()
    {
        Year sut = new Year(1800);
        Assert.False(sut.IsLeap());
    }

    [Test]
    public void Year1997IsNotLeap()
    {
        Year sut = new Year(1997);
        Assert.False(sut.IsLeap());
    }

    [Test]
    public void Year1996IsLeap()
    {
        Year sut = new Year(1996);
        Assert.False(sut.IsLeap());
    }
    
}

public class Year
{
    private int year;
    public Year(int year)
    {
        this.year = year;
    }

    public bool IsLeap()
    {
        if (year % 400 != 0 && year % 100 == 0)
        {
            return false;
        } 
        return (year%4 == 0 || year % 400 == 0);
    }
}