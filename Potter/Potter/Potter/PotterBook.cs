namespace Potter;

public class PotterBook(string name)
{
    private string _name = name;

    public static implicit operator PotterBook(string name) => new PotterBook(name);
}