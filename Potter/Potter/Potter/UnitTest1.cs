using NUnit.Framework.Constraints;

namespace Potter;

// Copia: 8€
//
// 2 -> 5%
// 3 -> 10%
// 4 -> 20%
// 5 -> 25%
//
// Tienen que ser distintos
// Los descuentos aplican por sets

public class Tests
{
    [Test]
    public void OneBookCosts8Euro()
    {
        var sut = new ShoppingCart();

        sut.Add("first book");

        Assert.That(sut.Price(), Is.EqualTo(8));
    }

    [Test]
    public void Emptycart()
    {
        var sut = new ShoppingCart();

        Assert.That(sut.Price(), Is.EqualTo(0));
    }

    [Test]
    public void TwoSameBooks()
    {
        var sut = new ShoppingCart();
        sut.Add("first book", "first book");
        Assert.That(sut.Price(), Is.EqualTo(16));
    }

    [Test]
    public void TwoDifferentBooksApplyDiscount()
    {
        var sut = new ShoppingCart();
        sut.Add("first book", "second book");
        Assert.That(sut.Price(), Is.EqualTo(15.2f));
    }

    [Test]
    public void ThreeDifferentBooksApplyDiscount()
    {
        var sut = new ShoppingCart();
        sut.Add("first book", "second book", "third book");
        Assert.That(sut.Price(), Is.EqualTo(21.6f));
    }

    [Test]
    public void Dadfasdf()
    {
        var sut = new ShoppingCart();
        sut.Add("first book", "third book");
        Assert.That(sut.Price(), Is.EqualTo(15.2f));
    }
}