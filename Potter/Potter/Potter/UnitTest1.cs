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

    [Test]
    public void BookIsPacked()
    {
        var sut = new ShoppingCart();
        int pack = sut.Pack("first book");
        Assert.That(pack, Is.EqualTo(1));
    }

    [Test]
    public void TwoBooksInSamePack()
    {
        var sut = new ShoppingCart();
        int pack = sut.Pack("first book", "fifth book");
        Assert.That(pack, Is.EqualTo(1));
    }

    [Test]
    public void TwoBooksInDifferentPacks()
    {
        var sut = new ShoppingCart();
        int pack = sut.Pack("first book", "first book");
        Assert.That(pack, Is.EqualTo(2));
    }

    [Test]
    public void METHOD()
    {
        var sut = new ShoppingCart();
        int pack = sut.Pack("second book", "second book");
        Assert.That(pack, Is.EqualTo(2));
    }

    [Test]
    public void ThreeBooksInThreePacks()
    {
        var sut = new ShoppingCart();
        int pack = sut.Pack("second book", "second book", "second book");
        Assert.That(pack, Is.EqualTo(3));
    }

    [Test]
    public void ThreeBooksInTwoPacks()
    {
        var sut = new ShoppingCart();
        int pack = sut.Pack("second book", "second book", "first book");
        Assert.That(pack, Is.EqualTo(2));
    }

    [Test]
    public void TwoPacksOfTwoBooks()
    {
        var sut = new ShoppingCart();
        int pack = sut.Pack("second book", "first book", "second book", "first book");
        Assert.That(pack, Is.EqualTo(2));
    }
    [Test]
    public void ThreeBooksSamePack()
    {
        var sut = new ShoppingCart();
        int pack = sut.Pack("first book", "second book", "third book");
        Assert.That(pack, Is.EqualTo(1));
    }
    
    
}