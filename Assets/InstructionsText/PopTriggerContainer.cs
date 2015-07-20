using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopTriggerContainer : MonoBehaviour 
{
	private Vector3 lightLev = new Vector3(4, 2, -1.5f);
	private Vector3 triggerLev = new Vector3(11.5f, 2, -3);
	private Vector3 zapLev = new Vector3(9, 2, -7);
	private Vector3 decoyLev = new Vector3(-8.8f, 2, -7.5f);


	private Renderer popRend;
	//private Material padExit = Resources.Load("ControlPadPop/ControlPadExitMat") as Texture;
	//private Material padDecoy = Resources.Load("ControlPadPop/ControlePads_put_decoy") as Texture;

	void Start()
	{
		popRend = GameObject.Find ("ControlPadPop").GetComponent<Renderer>();

		//lev 1
		if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstLightLevel)
		{
			transform.position = lightLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/ControlePadExit") as Texture;
		}
		//lev 2
		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstTriggerLevel)
		{
			transform.position = triggerLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/SwitchPop") as Texture;
		}
		//lev 3
		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstZapLevel)
		{
			transform.position = zapLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/ControlePadZap") as Texture;
		}
		//lev 4
		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDecoyLevel)
		{
			transform.position = decoyLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/ControlePadDecoy") as Texture;
		}
	}
	

		
}
