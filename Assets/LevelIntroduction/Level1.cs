using UnityEngine;
using System.Collections.Generic;

public class Level1 : LevelSetup {

	public List<Action> Setup(GameObject mainCamera, GameObject player1)
	{
		List<Action> actions = new List<Action>();

		//actions.Add(new MoveCameraAction(mainCamera, player1.transform.position));

		return actions;
	}


}
