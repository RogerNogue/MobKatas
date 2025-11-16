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
    public void KeepAliveBeforePassingNextGeneration() {
        GameOfLife sut = new GameOfLife();
        
        sut.ReviveCell(new Cell(0, 0));
        
        Assert.True(sut.IsAlive(new Cell(0, 0)));
    }

    [Fact]
    public void IsNotAliveIfWasNotRevived() {
        GameOfLife sut = new GameOfLife();
        
        Assert.False(sut.IsAlive(new Cell(0, 0)));
    }

    [Fact]
    public void KeepAliveBeforePassingNextGenerationIn1()
    {
        GameOfLife sut = new GameOfLife();
        
        sut.ReviveCell(new Cell(1,0));
        
        Assert.False((sut.IsAlive(new Cell(0,0))));
    }

    [Fact]
    public void NeighbourCellsSurviveAfterPassingGeneration()
    {
        GameOfLife sut = new GameOfLife();
        
        sut.ReviveCell(new Cell(0,0));
        sut.ReviveCell(new Cell(1,0));
        sut.ReviveCell(new Cell(2,0));

        sut.NextGen();
        
        Assert.True((sut.IsAlive(new Cell(1,0))));
    }

    [Fact]
    public void ZeroNeighboursByDefault() {
        CellsAlive sut = new();

        sut.Add(new Cell(0, 0));

        Assert.Equal(0, sut.GetNeighbours(new Cell(0, 0)));
    }

    [Fact]
    public void NeighboursAreAdjacentCells() {
        CellsAlive sut = new();
        
        sut.Add(new Cell(0, 0));
        sut.Add(new Cell(0, 1));
        sut.Add(new Cell(1, 0));
        
        Assert.Equal(2, sut.GetNeighbours(new Cell(0, 0)));
    }

    [Fact]
    public void TooFarAwayCellsAreNotNeighbours() {
        CellsAlive sut = new();
        
        sut.Add(new Cell(0, 0));
        sut.Add(new Cell(0, 2));
        sut.Add(new Cell(1, 0));
        
        Assert.Equal(1, sut.GetNeighbours(new Cell(0, 0)));
    }
    [Fact]
    public void AlignedCellsAreNeighbours() {
        CellsAlive sut = new();
        
        sut.Add(new Cell(0, 0));
        sut.Add(new Cell(1, 0));
        sut.Add(new Cell(2, 0));
        
        Assert.Equal(2, sut.GetNeighbours(new Cell(1, 0)));
    }


}




