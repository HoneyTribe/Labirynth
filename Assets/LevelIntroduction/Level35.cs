using UnityEngine;
using System.Collections.Generic;

public class Level35 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();

		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "You nearly have enough energy to make a *big* time shift..!"));
		
		return actions;
	}
	
	
}
