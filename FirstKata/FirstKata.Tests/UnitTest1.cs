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
    public void DieByUnderpopulation()
    {
      GameOfLife sut = new GameOfLife();
      sut.ReviveCell(new Cell(0, 0));

      sut.NextGen();

      Assert.False(sut.IsAlive(new Cell(0, 0)));
    }

    [Fact]
    public void METHOD() {
        GameOfLife sut = new GameOfLife();
        
        sut.ReviveCell(new Cell(0, 0));
        
        Assert.True(sut.IsAlive(new Cell(0, 0)));
    }
}