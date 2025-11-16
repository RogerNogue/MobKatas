namespace FirstKata.Tests;

public class GameOfLife {
	private bool isAlive;

	public void ReviveCell(Cell cell) {
		isAlive = true;
	}

	public void NextGen() {
		isAlive = false;
	}

	public bool IsAlive(Cell cell) {
		return isAlive;
	}
}