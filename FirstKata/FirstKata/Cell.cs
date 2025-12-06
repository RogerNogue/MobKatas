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
		cells.Add(new Cell(x - 1, y - 1));
		cells.Add(new Cell(x - 1, y));
		cells.Add(new Cell(x - 1, y + 1));
		cells.Add(new Cell(x, y - 1));
		cells.Add(new Cell(x, y + 1));
		cells.Add(new Cell(x + 1, y - 1));
		cells.Add(new Cell(x + 1, y));
		cells.Add(new Cell(x + 1, y + 1));
		cells = cells.Where(cell => cell.x >= 0 && cell.y >= 0).ToList();
		return cells;
	}

	public bool IsAdjacentTo(Cell cell) => Math.Abs((int)(x - cell.x)) <= 1 && Math.Abs((int)(y - cell.y)) <= 1 && !(x == cell.x && y == cell.y);

	public static Cell Origin() => new(0, 0);
}