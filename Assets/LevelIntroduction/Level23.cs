using UnityEngine;
using System.Collections.Generic;

public class Level23 : LevelSetup {
	
	public List<IntroAction> Setup()
	
	{
		List<IntroAction> actions = new List<IntroAction>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Sometimes the most simple solution is right in front of you."));

		return actions;
	}
	
	
}
