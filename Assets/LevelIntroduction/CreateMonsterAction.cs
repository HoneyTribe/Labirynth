using UnityEngine;
using System.Collections;

public class CreateMonsterAction : Action  {

	string monsterType;
	GameObject gameController;

	public CreateMonsterAction(string monsterType)
	{
		this.monsterType = monsterType;
		gameController = GameObject.Find ("GameController");
	}

	public void act()
	{
		if (GameObject.FindGameObjectWithTag("TempObject") == null)
		{
			gameController.SendMessage ("ShowMonster", monsterType);
		}
	}

	public bool isFinished()
	{
		return GameObject.FindGameObjectWithTag("TempObject") != null;
	}
}
