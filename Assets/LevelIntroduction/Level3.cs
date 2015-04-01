using UnityEngine;
using System.Collections.Generic;

public class Level3 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add(new ImageAction("tut_02"));
		actions.Add(new MoveCameraAction("DeviceContainer"));
		actions.Add(new TextAction(4, "This is the Decoy. Any maze-runner can move it."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, " But only the light-controller can zap hazards."));
		//actions.Add(new MoveCameraAction("Player1"));
		//actions.Add(new TextAction(4, "Zap-notized hazards will walk towards the decoy."));
		
		return actions;
	}
	
	
}
