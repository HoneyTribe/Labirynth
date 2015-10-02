using UnityEngine;
using System.Collections.Generic;

public class Level17 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();

		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Hmm, those buttons over there look different."));

		return actions;
	}
	
	
}
