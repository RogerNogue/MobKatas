namespace LeapYear;

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