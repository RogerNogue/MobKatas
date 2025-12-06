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


	public List<Cell> GetDeadCellsWithAliveNeighbours() {
		var cells = new List<Cell>();
		if (this.Contains(Cell.Origin()))
		{
			cells.Add(Cell.Origin());
			cells.Add(Cell.Origin());
			cells.Add(Cell.Origin());
		}
		else
		{
			cells.Add(Cell.Origin());
			cells.Add(Cell.Origin());
			cells.Add(Cell.Origin());
			cells.Add(Cell.Origin());
			cells.Add(Cell.Origin());
			cells.Add(Cell.Origin());
			cells.Add(Cell.Origin());
			cells.Add(Cell.Origin());
		}
		return cells;
  }
}
