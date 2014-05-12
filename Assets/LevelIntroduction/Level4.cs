using UnityEngine;
using System.Collections.Generic;

public class Level4 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "When in the crane: Tap your trigger to pick up or drop friends, items and monsters."));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Don't drain the crane's power too soon!"));

		return actions;
	}
	
	
}
