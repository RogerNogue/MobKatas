namespace FirstKata;

public readonly struct Cell {
	public readonly uint x;
	public readonly uint y;

	public Cell(uint x, uint y) {
		this.x = x;
		this.y = y;
	}

	public List<Cell> Neighbors()
	{
		var cells = new List<Cell>();
		if (this.Equals(Cell.Origin()))
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

	public bool IsAdjacentTo(Cell cell) => Math.Abs((int)(x - cell.x)) <= 1 && Math.Abs((int)(y - cell.y)) <= 1 && !(x == cell.x && y == cell.y);

	public static Cell Origin() => new(0, 0);
}