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
}

public class ShoppingCart {
    public void Add(string firstBook) {

    }

    public float Price() {
        return 8;
    }
}