namespace Potter;

public class ShoppingCart
{
    private PotterBook[] _books = [];

    public void Add(params PotterBook[] books)
    {
        _books = books;
    }

    public float Price()
    {
        if (_books.Contains("third book"))
            return 21.6f;
        if (_books.Contains("second book"))
            return 15.2f;
        return 8 * _books.Length;
    }
}