using UnityEngine;
using System.Collections.Generic;

public class Level22 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Are you feeling energetic?"));
		
		return actions;
	}
	
	
}
