using UnityEngine;
using System.Collections.Generic;

public class Level21 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new ImageAction("tut_16"));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Uh-oh. The Grabber was damaged during an upgrade..."));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "At least the upgrade still works!"));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "If you have full power aim over a wall and tap action-2."));
		
		return actions;
	}
	
	
}
