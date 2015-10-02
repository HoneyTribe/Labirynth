using UnityEngine;
using System.Collections.Generic;

public class Level19 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "The spirit of BFF is strong within you!"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "The reason we Chrosi have thrived as a species is because of our abilty to collaborate."));
		
		return actions;
	}
	
	
}
