using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopTriggerContainer : MonoBehaviour 
{
	private Vector3 lightlev = new Vector3(4, 2, -1.5f);
	private Vector3 decoylev = new Vector3(-8.8f, 2, -7.5f);

	void Start()
	{
		if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstLightLevel)
		{
			transform.position = lightlev;
		}

		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDecoyLevel)
		{
			transform.position = decoylev;
		}
	}
	

		
}
