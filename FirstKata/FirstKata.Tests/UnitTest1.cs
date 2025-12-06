namespace FirstKata.Tests;

/*
x - Any live cell with fewer than two live neighbours dies, as if caused by under-population.

x - Any live cell with two or three live neighbours lives on to the next generation.

x - Any live cell with more than three live neighbours dies, as if by overcrowding.

Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
 */

public class UnitTest1
{
    [Fact]
    public void DieByUnderpopulation()
    {
      GameOfLife sut = new GameOfLife();
      sut.ReviveCell(Cell.Origin());

      sut.NextGen();

      Assert.False(sut.IsAlive(Cell.Origin()));
    }

    [Fact]
    public void KeepAliveBeforePassingNextGeneration() {
        GameOfLife sut = new GameOfLife();
        
        sut.ReviveCell(Cell.Origin());
        
        Assert.True(sut.IsAlive(Cell.Origin()));
    }

    [Fact]
    public void IsNotAliveIfWasNotRevived() {
        GameOfLife sut = new GameOfLife();
        
        Assert.False(sut.IsAlive(Cell.Origin()));
    }

    [Fact]
    public void KeepAliveBeforePassingNextGenerationIn1()
    {
        GameOfLife sut = new GameOfLife();
        
        sut.ReviveCell(new Cell(1,0));
        
        Assert.False(sut.IsAlive(Cell.Origin()));
    }

    [Fact]
    public void NeighbourCellsSurviveAfterPassingGeneration()
    {
        GameOfLife sut = new GameOfLife();
        
        sut.ReviveCell(Cell.Origin());
        sut.ReviveCell(new Cell(1,0));
        sut.ReviveCell(new Cell(2,0));

        sut.NextGen();
        
        Assert.True(sut.IsAlive(new Cell(1,0)));
    }

    [Fact]
    public void ZeroNeighboursByDefault() {
        CellsAlive sut = new();

        sut.Add(Cell.Origin());

        Assert.Equal(0, sut.GetAliveNeighbours(Cell.Origin()));
    }

    [Fact]
    public void NeighboursAreAdjacentCells() {
        CellsAlive sut = new();
        
        sut.Add(Cell.Origin());
        sut.Add(new Cell(0, 1));
        sut.Add(new Cell(1, 0));
        
        Assert.Equal(2, sut.GetAliveNeighbours(Cell.Origin()));
    }

    [Fact]
    public void TooFarAwayCellsAreNotNeighbours() {
        CellsAlive sut = new();
        
        sut.Add(Cell.Origin());
        sut.Add(new Cell(0, 2));
        sut.Add(new Cell(1, 0));
        
        Assert.Equal(1, sut.GetAliveNeighbours(Cell.Origin()));
    }
    [Fact]
    public void AlignedCellsAreNeighbours() {
        CellsAlive sut = new();
        
        sut.Add(Cell.Origin());
        sut.Add(new Cell(1, 0));
        sut.Add(new Cell(2, 0));
        
        Assert.Equal(2, sut.GetAliveNeighbours(new Cell(1, 0)));
    }

    [Fact]
    public void NoNeighbourCellsDieAfterPassingGeneration()
    {
        GameOfLife sut = new GameOfLife();
        
        sut.ReviveCell(Cell.Origin());
        sut.ReviveCell(new Cell(1,0));
        sut.ReviveCell(new Cell(3,0));

        sut.NextGen();
        
        Assert.False(sut.IsAlive(Cell.Origin()));
        Assert.False(sut.IsAlive(new Cell(1,0)));
        Assert.False(sut.IsAlive(new Cell(3,0)));
    }

    [Fact]
    public void CellsWithoutEnoughNeighboursDie() {
        GameOfLife sut = new GameOfLife();

        sut.ReviveCell(Cell.Origin());
        sut.ReviveCell(new Cell(0, 1));
        sut.ReviveCell(new Cell(0, 2));

        sut.NextGen();

        Assert.False(sut.IsAlive(Cell.Origin()));
        Assert.False(sut.IsAlive(new Cell(0, 2)));
    }

    [Fact]
    public void DiagonalCellsAreNeighbours() {
        Assert.True(new Cell(2, 2).IsAdjacentTo(new Cell(1, 1)));
    }

    [Fact]
    public void CellsWithTooManyNeighboursDieByOverCrowding() {
        GameOfLife sut = new GameOfLife();

        sut.ReviveCell(new Cell(1, 1));
        sut.ReviveCell(new Cell(0, 0));
        sut.ReviveCell(new Cell(0, 1));
        sut.ReviveCell(new Cell(0, 2));
        sut.ReviveCell(new Cell(1, 0));

        sut.NextGen();

        Assert.False(sut.IsAlive(new Cell(1, 1)));
    }
    [Fact]
    public void CellsWith3NeighboursSurvive() {
        GameOfLife sut = new GameOfLife();

        sut.ReviveCell(new Cell(1, 1));
        sut.ReviveCell(new Cell(0, 0));
        sut.ReviveCell(new Cell(0, 1));
        sut.ReviveCell(new Cell(0, 2));

        sut.NextGen();

        Assert.True(sut.IsAlive(new Cell(1, 1)));
    }
    /*[Fact]
    public void DeadCellWith3NeighboursRevives() {
        GameOfLife sut = new GameOfLife();

        sut.ReviveCell(new Cell(0, 0));
        sut.ReviveCell(new Cell(0, 2));
        sut.ReviveCell(new Cell(2, 0));

        sut.NextGen();

        Assert.True(sut.IsAlive(new Cell(1, 1)));
    }*/

    [Fact]
    public void GetDeadCellsWithAliveNeighbours() {
        CellsAlive sut = new CellsAlive();

        sut.Add(Cell.Origin());

        Assert.Equal(3, sut.GetDeadCells().Count);
    }

    [Fact]
    public void GetDeadCellsWithAliveNeighboursByValues() {
        CellsAlive sut = new CellsAlive();

        sut.Add(new Cell(3, 3));

        Assert.Equal(8, sut.GetDeadCells().Count);
    }

    [Fact]
    public void GetAllNeighbourDeadCells() {
        var sut = new CellsAlive();

        sut.Add(Cell.Origin());
        sut.Add(new Cell(4, 4));

        Assert.Equal(11, sut.GetDeadCells().Count);
    }

    [Fact]
    public void GetAllNeighborsOfACell()
    {
        Cell sut = new Cell(2, 2);

        var neighbors = sut.Neighbors();
        
        Assert.Equal(neighbors.Count, 8);
        Assert.Contains(new Cell(1,1), neighbors);
        Assert.Contains(new Cell(1,2), neighbors);
        Assert.Contains(new Cell(1,3), neighbors);
    }

    [Fact]
    public void DoNotIncludeNegativeCoordinates() {
        var sut = Cell.Origin();
        
        Assert.Equal(3, sut.Neighbors().Count);
    }
    
    [Fact]
    public void dsafasfas() {
        var sut = new Cell(0, 1);
        
        Assert.Equal(5, sut.Neighbors().Count);
    }

    [Fact]
    public void NeighboursCoordinatesAreCorrect() {
        var sut = Cell.Origin();
        
        var neighbors = sut.Neighbors();
        
        Assert.Contains(new Cell(0,1), neighbors);
        Assert.Contains(new Cell(1,0), neighbors);
        Assert.Contains(new Cell(1,1), neighbors);
    }

    [Fact]
    public void METHOD()
    {
        var sut = new CellsAlive();

        sut.Add(Cell.Origin());
        sut.Add(new Cell(2, 2));

        Assert.Equal(sut.GetDeadCells().Count, 10);
    }

    [Fact]
    public void FilterOutAliveCells()
    {
        var sut = new CellsAlive();
    
        sut.Add(Cell.Origin());
        sut.Add(new Cell(1, 1));
    
        Assert.Equal(sut.GetDeadCells().Count, 7);
    }
}






