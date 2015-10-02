using UnityEngine;
using System.Collections.Generic;

public class Level11 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();

		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "Look at all that energy!"));
		
		return actions;
	}
	
	
}
