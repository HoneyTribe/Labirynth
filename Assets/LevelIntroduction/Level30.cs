﻿using UnityEngine;
using System.Collections.Generic;

public class Level30 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "You nearly have enough energy to make a *big* time shift..!"));
		
		return actions;
	}
	
	
}
