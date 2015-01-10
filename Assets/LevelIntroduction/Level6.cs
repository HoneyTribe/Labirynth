using UnityEngine;
using System.Collections.Generic;

public class Level6 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new ImageAction("tut_06"));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Upgrade! You have a Grabber!"));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Enter it and tap 'action-1' to pick up and drop things."));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Picking up costs power. Don't drain the power too soon!"));



		
		return actions;
	}
	
	
}
