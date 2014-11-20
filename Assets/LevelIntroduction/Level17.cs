﻿using UnityEngine;
using System.Collections.Generic;

public class Level17 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Let's see those lazer skills"));
		
		return actions;
	}
	
	
}
