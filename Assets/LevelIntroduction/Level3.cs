using UnityEngine;
using System.Collections.Generic;

public class Level3 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add(new ImageAction("tut_03"));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Each time you zap, the power is depleted temporarily."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "Never forget to revive your fallen friends! BFF or Die!"));
		
		return actions;
	}
	
	
}
