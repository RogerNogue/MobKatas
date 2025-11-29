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
    public void year_not_leap_if_not_divisible_by_4()
    {
        Year sut = new Year(3);

        Assert.False(sut.IsLeap());
    }

    [Test]
    public void year_is_leap_if_divisible_by_4()
    {
        Year sut = new Year(4);

        Assert.True(sut.IsLeap());
    }

    [Test]
    public void year_is_leap_if_divisible_by_400()
    {
        
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
        return year%4 == 0;
    }
}