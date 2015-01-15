using UnityEngine;
using System.Collections.Generic;

public class Level1 : LevelSetup {

	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		/*
		actions.Add (new ChangeCamAction());
		actions.Add(new ImageAction("tut_01"));
		//actions.Add (new WaitAction(0.4f));
		*/


		actions.Add(new ImageAction("tut_01"));
		//actions.Add (new WaitAction(1f));





		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "This is your Space-Time machine."));
		actions.Add(new MoveCameraAction("Key"));
		actions.Add(new TextAction(4, "Collect all the energy to fuel it and get back home."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "When all the energy is collected high-five to time shift."));

		return actions;
	}


}
