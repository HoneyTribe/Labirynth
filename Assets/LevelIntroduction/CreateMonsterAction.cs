using UnityEngine;
using System.Collections;

public class CreateMonsterAction : Action  {

	string monsterType;
	GameObject gameController;
	float time;

	public CreateMonsterAction(string monsterType)
	{
		this.monsterType = monsterType;
		gameController = GameObject.Find ("GameController");
	}

	public void act()
	{
		time += Time.deltaTime;
		gameController.SendMessage ("ShowMonster", monsterType);
	}

	public bool finished()
	{
		return GameObject.FindGameObjectWithTag("Monster") != null;
	}
}
