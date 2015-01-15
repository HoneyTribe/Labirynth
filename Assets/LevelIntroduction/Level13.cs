using UnityEngine;
using System.Collections.Generic;

public class Level13 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "The spirit of BFF is strong within you."));
		
		return actions;
	}
	
	
}
