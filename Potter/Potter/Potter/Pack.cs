using System.Collections;
using NUnit.Framework.Constraints;

namespace Potter;

public class Pack : IEnumerable<PotterBook> {
    public List<PotterBook> Books = [];

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
        if (Books.Count == 5)
            return (float)Math.Round(8 * 5 * 0.75f, 3);
        if (Books.Count == 4)
            return (float)Math.Round(8 * 4 * 0.8f, 3);
        if (Books.Count == 3)
            return (float)Math.Round(8 * 3 * .90f, 3);
        if (Books.Count == 2)
            return (float)Math.Round(8 * 2 * .95f, 3);
        return 8;
    }

    public static List<Pack> CreateFrom(params PotterBook[] books) {
        return books.Select(x => new Pack() { x }).ToList();
    }
}