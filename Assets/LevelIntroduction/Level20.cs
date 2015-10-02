using UnityEngine;
using System.Collections.Generic;

public class Level20 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();

		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Earth is a lot stranger than our historical records indicated."));
		
		return actions;
	}
	
	
}
