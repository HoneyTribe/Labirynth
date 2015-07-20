using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopTriggerContainer2 : MonoBehaviour 
{
	public static PopTriggerContainer2 instance;

	private Vector3 offScreen = new Vector3(-100, -10, -100f);
	private Vector3 lightLev = new Vector3(-10, 2, -1.5f);
	//private Vector3 triggerLev = new Vector3(11.5f, 2, -3);
	//private Vector3 zapLev = new Vector3(9, 2, -7);
	//private Vector3 decoyLev = new Vector3(-8.8f, 2, -7.5f);
	
	
	private Renderer popRend;
	
	void Start()
	{
		instance = this;
		popRend = GameObject.Find ("ControlPadPop2").GetComponent<Renderer>();

		//lev 1
		if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstLightLevel)
		{
			transform.position = offScreen;
			popRend.material.mainTexture = Resources.Load("PopTextures/HighFivePop") as Texture;
		}
		/*
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
		*/
	}

	//called from ScoreCOntroller
	public void movePopOnScreen()
	{
		transform.position = lightLev;
	}
	
	
	
}
