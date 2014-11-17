using UnityEngine;
using System.Collections.Generic;

public class Level14 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Key"));
		actions.Add(new TextAction(4, "Energy everywhere..!"));
	

		return actions;
	}
	
	
}
