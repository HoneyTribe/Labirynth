using UnityEngine;
using System.Collections.Generic;

public class Level2 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		//actions.Add(new CreateMonsterAction("Standard"));
		//actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Watch out for monsters!"));
		actions.Add(new MoveCameraAction("DeviceContainer"));
		actions.Add(new TextAction(4, "When in the maze: Tap your trigger button to drop the decoy."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "When in the light-machine: Aim at monsters and tap your trigger button. Zap to distract!"));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "Each time you zap monsters the power is depleted."));

		return actions;
	}
	
	
}
