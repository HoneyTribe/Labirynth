using UnityEngine;
using System.Collections.Generic;

public class Level2 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		//actions.Add(new CreateMonsterAction("Standard"));
		//actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new ImageAction("tut_02"));
		actions.Add(new MoveCameraAction("DeviceContainer"));
		actions.Add(new TextAction(4, "This is the Decoy. Move it and then activate it to distract monsters."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Maze runners: Tap 'action-1' to move the Decoy."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "Light-controller: Look at monsters and tap 'action-1' to send them to the Decoy."));

		return actions;
	}
	
	
}
