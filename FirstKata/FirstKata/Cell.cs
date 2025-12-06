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
			cells.Add(new Cell(0, 1));
			cells.Add(new Cell(1, 0));
			cells.Add(new Cell(1, 1));
		}
		else
		{
			cells.Add(new Cell(x - 1, y - 1));
			cells.Add(new Cell(x - 1, y));
			cells.Add(new Cell(x - 1, y + 1));
			cells.Add(new Cell(x, y - 1));
			cells.Add(new Cell(x, y + 1));
			cells.Add(new Cell(x + 1, y - 1));
			cells.Add(new Cell(x + 1, y));
			cells.Add(new Cell(x + 1, y + 1));
		}
		return cells;
	}

	public bool IsAdjacentTo(Cell cell) => Math.Abs((int)(x - cell.x)) <= 1 && Math.Abs((int)(y - cell.y)) <= 1 && !(x == cell.x && y == cell.y);

	public static Cell Origin() => new(0, 0);
}