using System.Collections;

namespace FirstKata.Tests;

public class GameOfLife {
	private CellsAlive cellsAlive = new();

	public void ReviveCell(Cell cell) {
		cellsAlive.Add(cell);
	}

	public void NextGen()
	{
		CellsAlive nextgenerationCells = new(); 
		foreach (var cell in cellsAlive)
		{
			if (cellsAlive.GetNeighbours(cell) is 2 or 3) nextgenerationCells.Add(cell);
		}

		cellsAlive = nextgenerationCells;
	}

	public bool IsAlive(Cell cell) {
		return cellsAlive.Contains(cell);
	}
}

public class CellsAlive : IEnumerable<Cell> {
	private List<Cell> cells = new();

	public void Add(Cell cell) {
		if (cells.Contains(cell))
			throw new Exception("Cell already added");
		cells.Add(cell);
	}

	

	public IEnumerator<Cell> GetEnumerator() {
		return cells.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}

	public int GetNeighbours(Cell cell) => cells.Count(aliveCell => aliveCell.IsAdjacentTo(cell));
}
