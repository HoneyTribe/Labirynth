public class PlayerSelectionState {

	private int id;
	private bool cursorOnStart;

	public PlayerSelectionState(int id)
	{
		this.id = id;
		this.cursorOnStart = false;
	}

	public void moveCursorOnStart()
	{
		this.cursorOnStart = true;
	}

	public void moveCursorOutOfStart()
	{
		this.cursorOnStart = false;
	}

	public int getId()
	{
		return id;
	}

	public bool isCursorOnStart()
	{
		return cursorOnStart;
	}
}
