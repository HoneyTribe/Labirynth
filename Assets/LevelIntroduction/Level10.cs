using UnityEngine;
using System.Collections.Generic;

public class Level10 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();

		actions.Add (new ChangeCamAction());
		actions.Add(new CreateMonsterAction("Standard"));
		actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new TextAction(4, "Something about those mummies is strange..."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "They seem alive as if in 20th century earth fiction. How..?"));

		return actions;
	}
	
	
}
