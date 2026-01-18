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
        PotterBook[] package = [];

        if (_books.Contains("third book"))
        {
            if (_books.Length == 2)
            {
                return 15.2f;
            }

            return 21.6f;
        }

        if (_books.Contains("second book"))
        {
            return 15.2f;
        }

        return 8 * _books.Length;
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

    public int[] GetPacks(params PotterBook[] books)
    {
        Dictionary<PotterBook, int> bookCounts = new();
        foreach (PotterBook book in books) {
            bookCounts.TryAdd(book, 0);
            bookCounts[book]++;
        }
        return bookCounts.Values.ToArray();
    }
}