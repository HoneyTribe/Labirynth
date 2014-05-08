using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class IntroductionController : MonoBehaviour {

	public Texture2D playersTexture;
	public Texture2D teacherTexture;

	private GameObject player1;
	private GameObject player2;
	private GameObject player3;
	private GameObject player4;
	private GameObject mainCamera;
	private List<Action> actions;
	private Action currentAction;
	
	private bool introductionFinished;

	private GUIStyle[] styles;

	void Start()
	{
		GUIStyle[] playerStyles = SpritesLoader.getPlayerSprites (playersTexture);
		List<GUIStyle> playerList = new List<GUIStyle> (playerStyles);
		playerList.Add(SpritesLoader.getTexture(teacherTexture));
		styles = playerList.ToArray ();

		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		player3 = GameObject.Find ("Player3");
		player4 = GameObject.Find ("Player4");
		mainCamera = GameObject.Find ("MainCamera_Front");

		Type type = Type.GetType ("Level1");
		actions = ((LevelSetup) Activator.CreateInstance(type)).Setup (mainCamera, player1);

		actions.Insert (0, new WaitAction (2f));
		actions.Add (new WaitAction(2f));
		actions.Add (new MoveCameraAction (mainCamera, mainCamera.transform.position, mainCamera.transform.rotation));

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
