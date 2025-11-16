using System.Collections;

namespace FirstKata.Tests;

public class GameOfLife {
	private CellsAlive CellsAlive = new();

	public void ReviveCell(Cell cell) {
		CellsAlive.Add(cell);
	}

	public void NextGen() {
    if (CellsAlive.Count() <= 2)
    {
		  CellsAlive.Clear();
    }
	}

	public bool IsAlive(Cell cell) {
		return CellsAlive.Contains(cell);
	}
}

public class CellsAlive : IEnumerable<Cell> {
	private List<Cell> cells = new();

	public void Add(Cell cell) {
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
}
