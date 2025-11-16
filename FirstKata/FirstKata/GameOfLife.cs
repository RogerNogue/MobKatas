namespace FirstKata.Tests;

public class GameOfLife {
	private bool generationPassed;
	public void ReviveCell(Cell cell) { }

	public void NextGen() {
		generationPassed = true;
	}

	public bool IsAlive(Cell cell) {
		return !generationPassed;
	}
}