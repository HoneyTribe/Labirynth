using UnityEngine;
using System.Collections.Generic;

public class Level13 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "You must really like this game! Keep in mind it's still an early demo though."));
		
		return actions;
	}
	
	
}
