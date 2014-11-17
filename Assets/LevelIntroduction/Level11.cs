using UnityEngine;
using System.Collections.Generic;

public class Level11 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("JumpContainer(Clone)"));
		actions.Add(new TextAction(4, "Look! An anti-grav box!"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Maze runners can pick up/drop by tapping Action-2. Then stand on top and get ready..."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "The light-controller can activate anti-grav by zapping friends with Action-2."));
		
		
		return actions;
	}
	
	
}
