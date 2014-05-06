using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class IntroductionController : MonoBehaviour {

	private GameObject player1;
	private GameObject player2;
	private GameObject player3;
	private GameObject player4;
	private GameObject mainCamera;
	private List<Action> actions;
	private Action currentAction;
	
	private bool introductionFinished;

	void Start()
	{
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		player3 = GameObject.Find ("Player3");
		player4 = GameObject.Find ("Player4");
		mainCamera = GameObject.Find ("MainCamera_Front");

		Type type = Type.GetType ("Level1");
		actions = ((LevelSetup) Activator.CreateInstance(type)).Setup (mainCamera, player1);
		currentAction = actions [0];
		actions.RemoveAt (0);
	}

	void Update()
	{
		if ((!introductionFinished) && (!LevelFinishedController.instance.isStopped()))
		{
			currentAction.act ();
			if (currentAction.finished())
			{
				if (actions.Count != 0)
				{
					currentAction = actions [0];
					actions.RemoveAt (0); 
				}
				else
				{
					introductionFinished = true;
				}
			}
		}
	}
}
