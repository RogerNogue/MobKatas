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