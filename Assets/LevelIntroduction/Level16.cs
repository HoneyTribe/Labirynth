using UnityEngine;
using System.Collections.Generic;

public class Level16 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "Uh-oh. The grabber was damaged during an upgrade..."));
		actions.Add(new MoveCameraAction("Crane"));
		actions.Add(new TextAction(4, "The upgrade works though. With full energy Tap Action-2 and use the Wall-Lazer!"));
		
		return actions;
	}
	
	
}
