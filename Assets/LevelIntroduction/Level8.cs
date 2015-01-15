using UnityEngine;
using System.Collections.Generic;

public class Level8 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Key"));
		actions.Add(new TextAction(4, "Look at all that energy!"));
		
		return actions;
	}
	
	
}
