using UnityEngine;
using System.Collections.Generic;

public class Level5 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add (new ChangeCamAction());

		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Each time you zap, the power is depleted temporarily."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "Touch your fallen friends to revive them! BFF or Die!"));

		return actions;
	}
	
	
}
