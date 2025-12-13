namespace Potter;

public class PotterBook
{
    private string _name;

    public PotterBook(string name)
    {
        _name = name;
    }
    public static implicit operator PotterBook(string name) => new PotterBook(name);
}