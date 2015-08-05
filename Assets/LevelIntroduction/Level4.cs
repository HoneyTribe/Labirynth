using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level4 : LevelSetup
{
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add(new ImageAction("tut_03"));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Upgrade! Now you have the decoy!"));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "Walk in the maze and tap action-1 to move the decoy."));

		return actions;
	}

		
}
