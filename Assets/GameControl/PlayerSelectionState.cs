public class PlayerSelectionState {

	public static int PLAYER = 0;
	public static int HELP = 1;
	public static int YOUTUBE = 2;
	public static int TWEET1 = 3;
	public static int FACEBOOK = 4;
	public static int VERSION = 5;

	private int id;
	private int positionInMenu;

	public PlayerSelectionState(int id)
	{
		this.id = id;
		this.positionInMenu = PLAYER;
	}

	public void moveCursorDown()
	{
		if (positionInMenu < VERSION)
		{
			this.positionInMenu++;
		}
	}

	public void moveCursorUp()
	{
		if (positionInMenu > PLAYER)
		{
			this.positionInMenu--;
		}
	}

	public int getId()
	{
		return id;
	}

	public int getPositionInMenu()
	{
		return positionInMenu;
	}
}
