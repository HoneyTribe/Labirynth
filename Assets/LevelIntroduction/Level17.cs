using UnityEngine;
using System.Collections.Generic;

public class Level17 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "You may not have been the best students at the Time Academy..."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "... but you are working well together. You make me proud."));
		
		return actions;
	}
	
	
}
