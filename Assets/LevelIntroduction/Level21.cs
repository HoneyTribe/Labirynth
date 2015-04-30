using UnityEngine;
using System.Collections.Generic;

public class Level21 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "The Teleport Drone, Grabber and Anti-Grav Box are all operational!"));

		return actions;
	}
	
	
}
