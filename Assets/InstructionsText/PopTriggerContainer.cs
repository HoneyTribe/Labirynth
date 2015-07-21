using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopTriggerContainer : MonoBehaviour 
{
	private Vector3 lightLev = new Vector3(10, 2, -1.5f);
	private Vector3 triggerLev = new Vector3(11.5f, 2, -3);
	private Vector3 zapLev = new Vector3(9, 2, -7);
	private Vector3 decoyLev = new Vector3(-8.8f, 2, -7.5f);
	private Vector3 chaseLev = new Vector3(12, 2, -18);
	private Vector3 craneLev = new Vector3(12, 2, -18);
	private Vector3 droneLev = new Vector3(12, 2, -18f);
	private Vector3 jumpLev = new Vector3(10, 2, -1.5f);
	private Vector3 stunLev = new Vector3(12, 2, -18);
	private Vector3 lazerLev = new Vector3(12, 2, -18);

	private Renderer popRend;

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
		//lev 6
		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstChaseLevel)
		{
			transform.position = chaseLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/HypnoPop") as Texture;
		}
		//lev 9
		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstCraneLevel)
		{
			transform.position = craneLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/CranePop") as Texture;
		}
		//lev 15
		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneLevel)
		{
			transform.position = droneLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/DronePop") as Texture;
		}
		//lev 18
		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstJumpBoxLevel)
		{
			transform.position = jumpLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/JumpPop") as Texture;
		}
		//lev 24
		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneBombLevel)
		{
			transform.position = stunLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/StunPop") as Texture;
		}
		//lev 27
		else if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstCraneLazerLevel)
		{
			transform.position = lazerLev;
			popRend.material.mainTexture = Resources.Load("PopTextures/LazerPop") as Texture;
		}
	}
	

		
}
