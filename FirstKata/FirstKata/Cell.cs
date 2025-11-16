namespace FirstKata.Tests;

public readonly struct Cell {
	public readonly uint x;
	public readonly uint y;

	public Cell(uint x, uint y) {
		this.x = x;
		this.y = y;
	}

	public bool IsAdjacentTo(Cell cell) => Math.Abs((int)(x - cell.x)) <= 1 && Math.Abs((int)(y - cell.y)) <= 1 && !(x == cell.x && y == cell.y);
}