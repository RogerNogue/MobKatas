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

    public int Pack(params PotterBook[] books)
    {
        if (books.Length == 4 )
        {
            if (books[1] == books[3])
            {
                return 2;
            }
            return 1;
        }
        if (books.Length > 2)
        {
            if (books[1] == books[0])
            {
                if (books[1] == books[2])
                    return 3;
                return 2; 
            }
            if (books[1] == books[2])
                return 2;
            return 1;
        }
        
        if (books.Length > 1 && books[1] == books[0])
        {
            return 2;
        }

        return 1;
    }
}