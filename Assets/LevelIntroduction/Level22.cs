using UnityEngine;
using System.Collections.Generic;

public class Level22 : LevelSetup {
	
	public List<Action> Setup()
	
	{
		List<Action> actions = new List<Action>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Try experimenting with what the Wall-Lazer can destroy."));
		
		return actions;
	}
	
	
}
