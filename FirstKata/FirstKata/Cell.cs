namespace FirstKata;

public readonly struct Cell {
	public readonly int x;
	public readonly int y;

	public Cell(int x, int y) {
		this.x = x;
		this.y = y;
	}

	public List<Cell> Neighbors()
	{
		var cells = new List<Cell>();
		if (this.Equals(Cell.Origin()))
		{
			cells.Add(new Cell(0, 1));
			cells.Add(new Cell(1, 0));
			cells.Add(new Cell(1, 1));
		}
		else {
			NewMethod(cells);
			cells = cells.Where(cell => cell.x >= 0 && cell.y >= 0).ToList();
		}
		return cells;
	}

	private void NewMethod(List<Cell> cells) {
		cells.Add(new Cell(x - 1, y - 1));
		cells.Add(new Cell(x - 1, y));
		cells.Add(new Cell(x - 1, y + 1));
		cells.Add(new Cell(x, y - 1));
		cells.Add(new Cell(x, y + 1));
		cells.Add(new Cell(x + 1, y - 1));
		cells.Add(new Cell(x + 1, y));
		cells.Add(new Cell(x + 1, y + 1));
	}

	public bool IsAdjacentTo(Cell cell) => Math.Abs((int)(x - cell.x)) <= 1 && Math.Abs((int)(y - cell.y)) <= 1 && !(x == cell.x && y == cell.y);

	public static Cell Origin() => new(0, 0);
}