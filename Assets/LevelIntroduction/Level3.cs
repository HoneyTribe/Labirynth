using UnityEngine;
using System.Collections.Generic;

public class Level3 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("DeviceContainer"));
		actions.Add(new TextAction(4, "Put the decoy in cunning places."));



		
		return actions;
	}
	
	
}
