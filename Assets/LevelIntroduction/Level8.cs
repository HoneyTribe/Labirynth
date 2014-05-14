using UnityEngine;
using System.Collections.Generic;

public class Level8 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Crane update! Now you can remove walls with the crane laser!"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Aim over a wall and tap your bumper when you have 100% power."));
		
		return actions;
	}
	
	
}
