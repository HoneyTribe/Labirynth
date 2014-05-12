﻿using UnityEngine;
using System.Collections.Generic;

public class Level2 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new TextAction(0, "Watch out for monsters!"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(1, "When in the maze: Tap your trigger button to drop the decoy."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(2, "When in the light-turret: Aim at monsters and tap your trigger button. Zap to distract!"));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(3, "Each time you zap monsters the light-turret's power is depleted."));

		return actions;
	}
	
	
}
