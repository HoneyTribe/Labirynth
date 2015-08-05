using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1 : LevelSetup
{
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		/*
		actions.Add (new ChangeCamAction());
		actions.Add(new ImageAction("tut_01"));
		//actions.Add (new WaitAction(0.4f));
		*/
			actions.Add (new ChangeCamAction());
			actions.Add(new MoveCameraAction("Lighthouse"));
			actions.Add(new TextAction(4, "Is everyone ok after the crash?!"));
			actions.Add(new MoveCameraAction("Player1"));
			actions.Add(new TextAction(4, "Luckily the Space-Time machine is still operational."));
			actions.Add(new MoveCameraAction("Key"));
			actions.Add(new TextAction(4, "Collect all the energy to refuel it and get back home."));
			actions.Add(new MoveCameraAction("Player2"));
			actions.Add(new TextAction(4, "When all the energy is collected high-five to time shift."));

		return actions;
	}


}
