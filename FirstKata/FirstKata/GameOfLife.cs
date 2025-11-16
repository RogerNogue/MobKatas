namespace FirstKata.Tests;

public class GameOfLife {
	private CellsAlive cellsAlive = new();

	public void ReviveCell(Cell cell) {
		cellsAlive.Add(cell);
	}

	public void NextGen() {
		CellsAlive nextgenerationCells = new();
		foreach (var cell in cellsAlive) {
			if (cellsAlive.GetNeighbours(cell) is 2 or 3) nextgenerationCells.Add(cell);
		}

		cellsAlive = nextgenerationCells;
	}

	public bool IsAlive(Cell cell) {
		return cellsAlive.Contains(cell);
	}
}