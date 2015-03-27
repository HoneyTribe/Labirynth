using UnityEngine;
using System.Collections.Generic;

public class Level2 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add (new ChangeCamAction());

		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Work together and eventually you'll find the way back home."));

		return actions;
	}
	
	
}
