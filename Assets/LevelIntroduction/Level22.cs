using UnityEngine;
using System.Collections.Generic;

public class Level22 : LevelSetup {
	
	public List<Action> Setup()
	
	{
		List<Action> actions = new List<Action>();
		
		actions.Add (new ChangeCamAction());
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "If your tactics are not working try adjusting the plan."));
		
		return actions;;
	}
	
	
}
