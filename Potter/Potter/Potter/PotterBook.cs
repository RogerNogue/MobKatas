namespace Potter;

public struct PotterBook(string name)
{
    private string _name = name;

    public static implicit operator PotterBook(string name) => new PotterBook(name);
    
    public static bool operator ==(PotterBook left, PotterBook right) => left._name == right._name;
    public static bool operator !=(PotterBook left, PotterBook right) => left._name != right._name;
    
    public static PotterBook LaPiedraFilosofal => new PotterBook("first book");
}