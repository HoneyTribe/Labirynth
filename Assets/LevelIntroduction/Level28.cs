using UnityEngine;
using System.Collections.Generic;

public class Level28 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Use the Grabber-Lazer wisely."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Oh yeah, the Decoy is operational again."));

		/*
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Ok we fixed everything! Think about your strategy..."));
		*/
		return actions;
	}
	
	
}
