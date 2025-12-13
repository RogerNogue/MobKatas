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
    public void Test1() {
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
        sut.Add("first book","first book");
        Assert.That(sut.Price(), Is.EqualTo(16));
    }
}

public class ShoppingCart
{
    private int WasCalled = 0;
    public void Add(params string [] firstBook)
    {
        WasCalled += 1;
    }

    public float Price() {
        
        if (WasCalled > 0)
        {
            return 8;
        }
        return 0;
    }
}