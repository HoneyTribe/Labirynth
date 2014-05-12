using UnityEngine;
using System.Collections.Generic;

public class Level3 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("JumpContainer(Clone)"));
		actions.Add(new TextAction(0, "To pick up or drop the anti-grav box tap your trigger when standing on it."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(1, "When in the light turret aim at the anti grav box and tap your bumper while your BFF is standing on it."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(2, "Use the light-turret's power wisely."));

		
		return actions;
	}
	
	
}
