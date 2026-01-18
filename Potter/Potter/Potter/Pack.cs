using System.Collections;

namespace Potter;

public class Pack : IEnumerable<PotterBook> {
    public List<PotterBook> Books = [];

    public void Add(PotterBook firstBook) {
        Books.Add(firstBook);
    }

    public IEnumerator<PotterBook> GetEnumerator() {
        return Books.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}