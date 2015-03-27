using UnityEngine;
using System.Collections.Generic;

public class Level12 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "Your teleporting skills are coming along nicely."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "I still don't know what caused the crash to Earth-space-time."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "I'll let you know if analysis reveals any information."));

		return actions;
	}
	
	
}
