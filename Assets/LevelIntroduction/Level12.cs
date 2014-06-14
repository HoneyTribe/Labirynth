using UnityEngine;
using System.Collections.Generic;

public class Level12 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "Your ninja skills have grown. You nearly finished this demo!"));

		
		return actions;
	}
	
	
}
