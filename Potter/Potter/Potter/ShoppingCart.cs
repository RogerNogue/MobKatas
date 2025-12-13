namespace Potter;

public class ShoppingCart
{
    private int _bookAmount = 0;

    public void Add(params PotterBook[] books)
    {
        _bookAmount += books.Length;
    }

    public float Price()
    {
        return 8 * _bookAmount;
    }
}