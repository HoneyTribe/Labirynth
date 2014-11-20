using UnityEngine;
using System.Collections.Generic;

public class Level11 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add(new ImageAction("tut_11"));
		actions.Add(new MoveCameraAction("JumpContainer(Clone)"));
		actions.Add(new TextAction(4, "Look! An anti-grav box!"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Maze runners:pick up/drop by tapping 'action-2.'"));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Light-controller: activate anti-grav by zapping friends with 'action-2'."));
		
		
		return actions;
	}
	
	
}
