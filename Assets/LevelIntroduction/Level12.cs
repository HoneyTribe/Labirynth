using UnityEngine;
using System.Collections.Generic;

public class Level12 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new ImageAction("tut_11"));
		actions.Add(new MoveCameraAction("JumpContainer(Clone)"));
		actions.Add(new TextAction(4, "Look! An Anti-Grav Box!"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Tap action-2 to pick up or drop it."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Aim the light at a friend who is standing on it and tap action 2."));
		
		return actions;
	}
	
	
}
