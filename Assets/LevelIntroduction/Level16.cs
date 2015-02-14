using UnityEngine;
using System.Collections.Generic;

public class Level16 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Keep collecting that energy. We need it to time-shift back home."));
		
		return actions;
	}
	
	
}
