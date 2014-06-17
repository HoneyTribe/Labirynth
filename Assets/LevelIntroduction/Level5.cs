using UnityEngine;
using System.Collections.Generic;

public class Level5 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Upgrade! You have a crane! Tap your trigger to pick up or drop friends, items and monsters."));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Picking up costs power. Don't drain the power too soon!"));

		
		return actions;
	}
	
	
}
