using UnityEngine;
using System.Collections.Generic;

public class Level4 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(0, "When in the crane tap yout trigger to pick up or drop friends, items and monsters."));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(1, "Don't drain the crane's energy too soon!"));

		return actions;
	}
	
	
}
