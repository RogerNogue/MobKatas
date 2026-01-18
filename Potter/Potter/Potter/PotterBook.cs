namespace Potter;

public struct PotterBook(string name)
{
    private string _name = name;
    public const float Price = 8;

    public static implicit operator PotterBook(string name) => new PotterBook(name);
    
    public static bool operator ==(PotterBook left, PotterBook right) => left._name == right._name;
    public static bool operator !=(PotterBook left, PotterBook right) => left._name != right._name;
    
    public static PotterBook First => new PotterBook("first book");
    public static PotterBook Second => new PotterBook("second book");
    public static PotterBook Third => new PotterBook("third book");
    public static PotterBook Fourth => new PotterBook("fourth book");
    public static PotterBook Fifth => new PotterBook("fifth book");
}