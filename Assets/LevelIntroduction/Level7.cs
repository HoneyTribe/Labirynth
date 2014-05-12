using UnityEngine;
using System.Collections.Generic;

public class Level7 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		

		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(0, "When using the drone: Tap your bumper to drop a stun bomb."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(1, "Stunned monsters will freeze for a few seconds."));
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(2, "Power is used each time you drop a stun bomb."));
		
		return actions;
	}
	
	
}
