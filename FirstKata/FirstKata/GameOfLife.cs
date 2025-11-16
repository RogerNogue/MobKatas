namespace FirstKata.Tests;

public class GameOfLife {
	private List<Cell> CellsAlive = new();

	public void ReviveCell(Cell cell) {
		CellsAlive.Add(cell);
	}

	public void NextGen() {
		CellsAlive.Clear();
	}

	public bool IsAlive(Cell cell) {
		return CellsAlive.Contains(cell);
	}
}