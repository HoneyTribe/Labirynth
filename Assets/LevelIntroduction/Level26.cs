using UnityEngine;
using System.Collections.Generic;

public class Level26 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();
	
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Don't let fear slow you down!"));

		return actions;
	}
	
	
}
