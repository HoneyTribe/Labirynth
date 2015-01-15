using UnityEngine;
using System.Collections.Generic;

public class Level5 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add (new ChangeCamAction());
		actions.Add(new CreateMonsterAction("Flying"));
		actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new TextAction(4, "Ghosts can float through walls!"));

		return actions;
	}
	
	
}
