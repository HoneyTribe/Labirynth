using UnityEngine;
using System.Collections.Generic;

public class Level9 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add (new ChangeCamAction());
		actions.Add(new CreateMonsterAction("Standard"));
		actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new TextAction(4, "Something about those mummies is strange..."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Analysis reveals that ancient Egyptian mummification was a ritual for dead humans."));
		actions.Add(new CreateMonsterAction("Standard"));
		actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new TextAction(4, "Yet they seem alive as if in 20th century earth fiction...?"));

		return actions;
	}
	
	
}
