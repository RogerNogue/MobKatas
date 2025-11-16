using System.Collections;

namespace FirstKata.Tests;

public class GameOfLife {
	private CellsAlive cellsAlive = new();

	public void ReviveCell(Cell cell) {
		cellsAlive.Add(cell);
	}

	public void NextGen() {
    if (cellsAlive.Count() <= 2)
    {
		  cellsAlive.Clear();
    }
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

	public void Clear() {
		cells.Clear();
	}

	public IEnumerator<Cell> GetEnumerator() {
		return cells.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}

	public int GetNeighbours(Cell cell) {
		return 0;
	}
}
