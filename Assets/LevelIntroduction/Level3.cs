﻿using UnityEngine;
using System.Collections.Generic;

public class Level3 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add(new ImageAction("tut_02"));
		actions.Add(new MoveCameraAction("DeviceContainer"));
		actions.Add(new TextAction(4, "This is the Decoy. Use it to distract dangerous lifeforms."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Any maze-runner can move the Decoy."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "But only the light-controller can zap organisms."));
		
		return actions;
	}
	
	
}
