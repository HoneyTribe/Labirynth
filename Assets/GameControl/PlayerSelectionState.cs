﻿public class PlayerSelectionState {

	public static int PLAYER = 0;
	public static int START = 1;
	public static int HELP = 2;

	private int id;
	private int positionInMenu;

	public PlayerSelectionState(int id)
	{
		this.id = id;
		this.positionInMenu = PLAYER;
	}

	public void moveCursorDown()
	{
		if (positionInMenu < HELP)
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
