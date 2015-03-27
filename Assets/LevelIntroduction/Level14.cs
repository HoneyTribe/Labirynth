using UnityEngine;
using System.Collections.Generic;

public class Level14 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "The teleport drone will be in maintenance for a while."));
		
		return actions;
	}
	
}
