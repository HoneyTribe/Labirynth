using UnityEngine;
using System.Collections.Generic;

public class Level8 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();

		actions.Add (new ChangeCamAction());
		actions.Add(new CreateMonsterAction("Flying"));
		actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new TextAction(4, "A ghost?! How is this possible..?"));
		
		return actions;
	}
	
	
}
