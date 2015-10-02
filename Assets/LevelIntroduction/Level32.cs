using UnityEngine;
using System.Collections.Generic;

public class Level32 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "There is no I in BFF..."));
		
		return actions;
	}
	
	
}
