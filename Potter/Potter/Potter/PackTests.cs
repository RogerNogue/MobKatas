namespace Potter;

public class PackTests {
	[Test]
	public void BookIsPacked()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks("first book");
		Assert.That(pack, Is.EqualTo(1));
	}

	[Test]
	public void TwoBooksInSamePack()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks("first book", "fifth book");
		Assert.That(pack, Is.EqualTo(1));
	}

	[Test]
	public void TwoBooksInDifferentPacks()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks("first book", "first book");
		Assert.That(pack, Is.EqualTo(2));
	}

	[Test]
	public void METHOD()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks("second book", "second book");
		Assert.That(pack, Is.EqualTo(2));
	}

	[Test]
	public void ThreeBooksInThreePacks()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks("second book", "second book", "second book");
		Assert.That(pack, Is.EqualTo(3));
	}

	[Test]
	public void ThreeBooksInTwoPacks()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks("second book", "second book", "first book");
		Assert.That(pack, Is.EqualTo(2));
	}

	[Test]
	public void TwoPacksOfTwoBooks()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks("second book", "first book", "second book", "first book");
		Assert.That(pack, Is.EqualTo(2));
	}

	[Test]
	public void ThreeBooksSamePack()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks("first book", "second book", "third book");
		Assert.That(pack, Is.EqualTo(1));
	}

	[Test]
	public void cccccccccc()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks("fifth book", "first book", "second book", "first book");
		Assert.That(pack, Is.EqualTo(2));
	}

	[Test]
	public void cccccccccch()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks( "first book", "second book", "fourth book", "third book");
		Assert.That(pack, Is.EqualTo(1));
	}

	[Test]
	public void TestForThree()
	{
		var sut = new ShoppingCart();
		int pack = sut.GetAmountOfPacks( "first book", "third book", "third book");
		Assert.That(pack, Is.EqualTo(2));
	}

	[Test]
	public void FullPack()
	{
        var sut = new ShoppingCart();
        int pack = sut.GetAmountOfPacks("first book", "third book", "fourth book", "second book", "fifth book");
        Assert.That(pack, Is.EqualTo(1));
    }

	[Test]
	public void CreatePackOfOneBook() {
		var pack = new Pack();
		pack.Add("first book");
		Assert.That(pack, Contains.Item(new PotterBook("first book")));
	}

	[Test]
	public void OneBookCosts8Euros() {
		var pack = new Pack();
		pack.Add("first book");
		Assert.That(pack.Price(), Is.EqualTo(8));
	}

	[Test]
	public void TwoBooks() {
		var pack = new Pack();
		pack.Add("first book");
		pack.Add("second book");
		Assert.That(pack.Price(), Is.EqualTo(15.2f));
	}

	[Test]
	public void ThreeBooks()
	{
		var pack = new Pack();
		pack.Add("first book");
		pack.Add("second book");
		pack.Add("third book");
		Assert.That(pack.Price(), Is.EqualTo(21.6f));
	}

	[Test]
	public void FourBooks()
	{
		var pack = new Pack();
		pack.Add("first book");
		pack.Add("second book");
		pack.Add("third book");
		pack.Add("fourth book");
		Assert.That(pack.Price(), Is.EqualTo(25.6f));
	}
	
	[Test]
	public void FiveBooks()
	{
		var pack = new Pack();
		pack.Add("first book");
		pack.Add("second book");
		pack.Add("third book");
		pack.Add("fourth book");
		pack.Add("fifth book");
		Assert.That(pack.Price(), Is.EqualTo(30f));
	}

	[Test]
	public void PackOfOneBook() {
		var packs = Pack.CreateFrom(PotterBook.First);
		Assert.That(packs.Count, Is.EqualTo(1));
		Assert.That(packs.Single(), Contains.Item(PotterBook.First));
	}
}