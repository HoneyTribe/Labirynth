using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level5 : LevelSetup
{
	private GameObject robot;
	
	public List<IntroAction> Setup()
	{
		robot = GameObject.Find("Player5");

		List<IntroAction> actions = new List<IntroAction>();

		if(robot == null)
		{
			actions.Add (new ChangeCamAction());
			actions.Add(new MoveCameraAction("Lighthouse"));
			actions.Add(new TextAction(4, "Each time you zap, the power is depleted temporarily."));
			actions.Add(new MoveCameraAction("Player1"));
			actions.Add(new TextAction(4, "Touch your fallen friends to revive them! BFF or Die!"));
		}
		else
		{
			actions.Add (new ChangeCamAction());
			actions.Add(new MoveCameraAction("Lighthouse"));
			actions.Add(new TextAction(4, "Each time you zap, the power is depleted temporarily."));
		}

		return actions;
	}
	
	
}
