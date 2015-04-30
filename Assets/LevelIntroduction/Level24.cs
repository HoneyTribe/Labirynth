using UnityEngine;
using System.Collections.Generic;

public class Level24 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "The Teleport Drone is broken... and the Decoy too. But..."));
		actions.Add(new MoveCameraAction("Drone"));
		actions.Add(new TextAction(4, "We installed a new abilty! Drop stun bombs by tapping action-2."));

		return actions;
	}
	
	
}
