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
        return Pack.Split(_books).Sum(book => book.Price());
    }

    public int GetAmountOfPacks(params PotterBook[] books)
    {
        Dictionary<PotterBook, int> bookCounts = new();
        foreach (PotterBook book in books) {
            bookCounts.TryAdd(book, 0);
            bookCounts[book]++;
        }
        return bookCounts.Max(kvp => kvp.Value);
    }

    
}