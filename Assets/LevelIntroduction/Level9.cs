﻿using UnityEngine;
using System.Collections.Generic;

public class Level9 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();

		actions.Add(new ImageAction("tut_06"));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Upgrade! You have a Grabber!"));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Now you can pick up and drop things."));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Picking up costs power. Don't drain the power too soon!"));

		return actions;
	}
	
	
}
