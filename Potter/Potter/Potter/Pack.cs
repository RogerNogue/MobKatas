using System.Collections;
using NUnit.Framework.Constraints;

namespace Potter;

public class Discounts
{
    public static List<float> discounts = new List<float>()
    {
        0,1,0.95f, 0.90f, 0.80f, 0.75f,  
    };

    public float Discount(List<PotterBook> books)
    {
        return discounts[books.Count];
    }
}

public class Pack : IEnumerable<PotterBook> {
    public List<PotterBook> Books = [];
    private readonly Discounts _discounts = new Discounts();

    public void Add(PotterBook book) {
        if (Books.Contains(book))
            throw new InvalidOperationException("Book already exists");
        Books.Add(book);
    }

    public IEnumerator<PotterBook> GetEnumerator() {
        return Books.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public float Price()
    {
        return (float)Math.Round(PotterBook.Price * Books.Count * _discounts.Discount(Books), 3);
    }

    public static Pack Of(params PotterBook[] books) {
        var pack = new Pack();
        foreach (var book in books) {
            pack.Add(book);
        }
        return pack;
    }

    public static List<Pack> Split(params PotterBook[] books) {
        var packs = new List<Pack>();
        foreach (var book in books) {
            var pack = packs.FirstOrDefault(p => !p.Books.Contains(book));
            if (pack == null) {
                pack = new Pack();
                packs.Add(pack);
            }
            pack.Add(book);
        }
        return packs;
    }

    protected bool Equals(Pack other) {
        return Books.SequenceEqual(other.Books);
    }

    public override bool Equals(object? obj) {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Pack)obj);
    }

    public override int GetHashCode() {
        return Books.GetHashCode();
    }
}