﻿using UnityEngine;
using System.Collections.Generic;

public class Level10 : LevelSetup {
	
	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();
		
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(4, "Never forget to revive your fallen friends. BFF or Die!"));

		return actions;
	}
	
	
}