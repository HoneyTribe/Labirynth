using UnityEngine;
using System.Collections.Generic;

public class Level13 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Remember your training from the Time Academy... BFF or Die!"));

		return actions;
	}
	
	
}
