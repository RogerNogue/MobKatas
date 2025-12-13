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
        return 8 * _books.Length;
    }
}