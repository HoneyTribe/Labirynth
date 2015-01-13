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
		actions.Add(new TextAction(4, "This is the Decoy. Use it to distract monsters."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Any maze-runner can move the Decoy."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "Only the Light-operator can activate the Decoy."));

		return actions;
	}
	
	
}
