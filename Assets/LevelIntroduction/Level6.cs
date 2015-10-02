﻿using UnityEngine;
using System.Collections.Generic;

public class Level6 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Explore the maze carefully."));
	
		return actions;
	}
	
	
}
