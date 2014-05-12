﻿using UnityEngine;
using System.Collections.Generic;

public class Level5 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new TextAction(0, "Ghosts can walk through walls!."));
		
		return actions;
	}
	
	
}
