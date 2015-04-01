using UnityEngine;
using System.Collections.Generic;

public class Level26 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
	
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "You are true BFF samurai..!"));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "When you get back home I'm promoting you all to the Elite Class."));

		return actions;
	}
	
	
}
