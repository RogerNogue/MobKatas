using System.Collections;

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
}