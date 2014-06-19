using UnityEngine;
using System.Collections.Generic;

public class Level15 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "You are true samurai. You nearly finished this demo of BFF or Die!"));
		
		return actions;
	}
	
	
}
