using UnityEngine;
using System.Collections.Generic;

public class Level20 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Ok this level is *really* hard. Good luck..."));
		
		return actions;
	}
	
	
}
