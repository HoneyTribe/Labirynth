using UnityEngine;
using System.Collections.Generic;

public class Level6 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(0, "When in the drone: Tap your trigger to drop teleports."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(1, "When two teleports are dropped friends and monsters can pass between them."));
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(3, "Each drop uses power. Aim carefully!"));
		
		return actions;
	}
	
	
}
