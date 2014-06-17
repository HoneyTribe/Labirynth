using UnityEngine;
using System.Collections.Generic;

public class Level11 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		


		actions.Add(new MoveCameraAction("JumpContainer(Clone)"));
		actions.Add(new TextAction(4, "To pick up or drop the anti-grav box tap your bumper while standing on it."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "When in the light machine: Aim at the anti-grav box and tap bumper while your friend is standing on it."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "You can also force monsters to jump! Use power reserves wisely."));

		
		return actions;
	}
	
	
}
