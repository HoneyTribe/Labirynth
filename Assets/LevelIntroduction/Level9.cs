using UnityEngine;
using System.Collections.Generic;

public class Level9 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "Upgrade! You have a teleport drone! Tap Action-1 to drop teleports."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "When two teleports are dropped, friends and monsters can pass between them."));
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "Each drop uses power. Aim carefully!"));

		return actions;
	}
	
	
}
