using UnityEngine;
using System.Collections.Generic;

public class Level1 : LevelSetup {

	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "This is your Space-Time machine."));
		actions.Add(new MoveCameraAction("Key"));
		actions.Add(new TextAction(4, "Collect all the energy to fuel the Space-Time machine."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "When all the energy is collected everyone needs to high-five to time shift."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Hold down Action-1 to exit the light."));

		return actions;
	}


}
