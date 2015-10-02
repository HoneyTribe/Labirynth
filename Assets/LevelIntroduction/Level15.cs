using UnityEngine;
using System.Collections.Generic;

public class Level15 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();

		actions.Add(new ImageAction("tut_09"));
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "Upgrade! You have a Teleport Drone!"));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "When two teleports are dropped, lifeforms can pass between them."));
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "Each drop uses power. Aim carefully!"));

		return actions;
	}
	
	
}
