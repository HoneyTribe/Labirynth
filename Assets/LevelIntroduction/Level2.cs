using UnityEngine;
using System.Collections.Generic;

public class Level2 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		//actions.Add(new CreateMonsterAction("Standard"));
		//actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new MoveCameraAction("DeviceContainer"));
		actions.Add(new TextAction(4, "This is the Decoy. Use it to distract guards and monsters."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "The maze runners can tap Action-1 to position the Decoy."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "The light-controller can tap Action-1 to zap & distract."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Touch your fallen friends to revive them!"));

		return actions;
	}
	
	
}
