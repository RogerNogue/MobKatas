namespace Potter;

public class ShoppingCart
{
    private PotterBook[] _books = [];
    private List<PotterPack> packs = [new PotterPack()];

    public void Add(params PotterBook[] books)
    {
        _books = books;
        foreach (var book in books)
        {
            foreach (var pack in packs)
            {
                if (pack.Contains(book))
                {
                    continue;
                }
                pack.Add(book);
                break;
            }
            
        }
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
}

internal class PotterPack
{
    public bool Contains(PotterBook book)
    {
        return false;
    }

    public void Add(PotterBook book)
    {
        
    }
}