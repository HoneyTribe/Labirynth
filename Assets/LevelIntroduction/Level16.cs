using UnityEngine;
using System.Collections.Generic;

public class Level16 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "Your teleporting skills are coming along nicely."));

		return actions;
	}
	
	
}
