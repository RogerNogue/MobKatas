using System.Collections;

namespace FirstKata;

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

	public int GetAliveNeighbours(Cell cell) => cells.Count(aliveCell => aliveCell.IsAdjacentTo(cell));


	public List<Cell> GetDeadCells() {
		var resultCells = new List<Cell>();
		foreach (var cell in this.cells)
		{
			resultCells.AddRange(cell.Neighbors());
		}
		
		return resultCells.Distinct().ToList();
  }
}
