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
            return 30f;
        if (Books.Count == 4)
            return 25.6f;
        if (Books.Count == 3)
            return 21.6f;
        if (Books.Count == 2)
            return 15.2f;
        return 8;
    }
}