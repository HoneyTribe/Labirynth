using UnityEngine;
using System.Collections.Generic;

public class Level7 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		

		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "Drone upgrade! Tap your bumper to drop a stun bomb."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Stunned monsters will freeze for a few seconds."));
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "Power is used each time you drop a stun bomb."));
		
		return actions;
	}
	
	
}
