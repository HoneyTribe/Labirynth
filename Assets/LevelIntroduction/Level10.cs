﻿using UnityEngine;
using System.Collections.Generic;

public class Level10 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "There is no I in BFF..."));

		return actions;
	}
	
	
}
