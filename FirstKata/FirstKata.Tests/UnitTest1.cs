namespace FirstKata.Tests;

/*
Any live cell with fewer than two live neighbours dies, as if caused by under-population.
Any live cell with two or three live neighbours lives on to the next generation.
Any live cell with more than three live neighbours dies, as if by overcrowding.
Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
 */

public class UnitTest1
{
    [Fact]
    public void aslkhgdr()
    {
      GameOfLife sut = new GameOfLife();
      sut.AddCell(0, 0);
      sut.NextGen();
      Assert.False(sut.IsAlive(0, 0));
    }
}


public class GameOfLife
{
  public void AddCell(int x, int y)
  {

  }

  public void NextGen()
  {

  }

  public bool IsAlive(int x, int y)
  {
    return false;
  }
}
