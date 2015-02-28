﻿using UnityEngine;
using System.Collections.Generic;

public class Level23 : LevelSetup {
	
	public List<Action> Setup()
	
	{
		List<Action> actions = new List<Action>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "You are true BFF samurai..!"));
		
		return actions;
	}
	
	
}