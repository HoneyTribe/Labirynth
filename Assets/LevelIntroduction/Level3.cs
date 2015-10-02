using UnityEngine;
using System.Collections.Generic;

public class Level3 : LevelSetup {
	
	public List<IntroAction> Setup()
	{
		List<IntroAction> actions = new List<IntroAction>();

		actions.Add(new ImageAction("tut_02"));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "Upgrade! You can now hypnotize dangerous life-forms with the zapper!"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(4, "Aim the light at mummies. Tap action-1 to zap them."));
		//actions.Add(new MoveCameraAction("Player1"));
		//actions.Add(new TextAction(4, "Zap-notized hazards will walk towards the decoy."));
		
		return actions;
	}
	
	
}
