using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class IntroductionController : MonoBehaviour {

	public static IntroductionController instance;

	public const int dialogSizeX = 600;
	public const int dialogSizeY = 100;

	public Texture2D playersTexture;
	public Texture2D teacherTexture;

	private List<Action> actions;
	private Action currentAction;
	private Action movingBackAction;
	
	private bool playingIntroduction = true;
	private bool stoppingIntroduction = false;
	private bool stoppedIntroduction = false;

	private GUIStyle[] styles;
	private int textureId = -1;
	private string text = null;

	private GUIStyle borderStyle;
	private GUIStyle outerStyle;

	public GUISkin guiSkin;

	void Start()
	{
		instance = this;

		GUIStyle[] playerStyles = SpritesLoader.getPlayerSprites (playersTexture);
		List<GUIStyle> playerList = new List<GUIStyle> (playerStyles);
		playerList.Add(SpritesLoader.getTexture(teacherTexture));
		styles = playerList.ToArray ();

		GameObject mainCamera = GameObject.Find ("MainCamera_Front");

		Type type = Type.GetType ("Level" + (LevelFinishedController.instance.getLevel() + 1));
		if (type != null)
		{
			actions = ((LevelSetup) Activator.CreateInstance (type)).Setup ();

			actions.Insert (0, new WaitAction (1f));
			actions.Add (new WaitAction(1f));

			movingBackAction = new MoveCameraAction (mainCamera.transform.position, mainCamera.transform.rotation);

			currentAction = actions [0];
			actions.RemoveAt (0);

			// GUI

			borderStyle = new GUIStyle ();
			Texture2D borderTexture = new Texture2D (1, 1);
			borderTexture.SetPixel (0, 0, Color.white);
			borderTexture.Apply ();
			borderStyle.normal.background = borderTexture;
			
			outerStyle = new GUIStyle ();
			Texture2D outerTexture = new Texture2D (1, 1);
			outerTexture.SetPixel (0, 0, Color.black);
			outerTexture.Apply ();
			outerStyle.normal.background = outerTexture;
		}
		else
		{
			playingIntroduction = false;
			LevelFinishedController.instance.Reset();
		}
	}

	void Update()
	{
		if (playingIntroduction)
		{
			currentAction.act ();
			if (currentAction.isFinished())
			{
				if (actions.Count > 1)
				{
					currentAction = actions [0];
					actions.RemoveAt (0); 
				}
				else
				{
					StopIntroduction(true);
				}
			}
		}

		if (stoppingIntroduction)
		{
			// Clean other actions
			if (!stoppedIntroduction)
			{
				GameObject[] monters = GameObject.FindGameObjectsWithTag("TempObject");
				foreach (GameObject monster in monters)
				{
					Destroy(monster);
				}
				GameObject monsterDoorLeft = GameObject.Find ("monsterDoorLeft");
				monsterDoorLeft.SendMessage("CloseDoor");

				textureId = -1;
				text = null;
				stoppedIntroduction = true;
			}

			movingBackAction.act();
			if (movingBackAction.isFinished())
			{
				stoppingIntroduction = false;
				LevelFinishedController.instance.Reset();
			}
		}
	}

	public void StopIntroduction(bool stopping)
	{
		playingIntroduction = false;
		stoppingIntroduction = stopping;
	}

	public bool isPlayingIntroduction()
	{
		return playingIntroduction;
	}

	void OnGUI () 
	{
		if ((textureId != -1) && (text != null))
		{
			GUI.BeginGroup(new Rect ((Screen.width / 2) - dialogSizeX / 2, 10, dialogSizeX, dialogSizeY));
				GUI.Box (new Rect (0, 0, dialogSizeX, dialogSizeY), "", borderStyle);
				GUI.Box (new Rect (1, 1, dialogSizeX - 2, dialogSizeY - 2), "", outerStyle);

				//GUI.Box (new Rect (10, 10, dialogSizeY - 20, dialogSizeY - 20), "", borderStyle);
				//GUI.Box (new Rect (11, 11, dialogSizeY - 20 - 2, dialogSizeY - 20 - 2), "", outerStyle);
				GUI.DrawTexture (new Rect (10, 10, dialogSizeY - 20, dialogSizeY - 20), styles[textureId].normal.background);

				GUI.Box (new Rect (dialogSizeY, 10, dialogSizeX - dialogSizeY - 10, dialogSizeY - 20), "", borderStyle);
				GUI.Box (new Rect (dialogSizeY + 1, 11, dialogSizeX - dialogSizeY - 10 - 2, dialogSizeY - 20 - 2), "", outerStyle);
				
			GUI.Label (new Rect (dialogSizeY + 10, 20, dialogSizeX - dialogSizeY - 30, dialogSizeY - 40), text, guiSkin.label);
			GUI.EndGroup();
		}
		
	}

	public void setTextureId(int textureId)
	{
		this.textureId = textureId;
	}

	public void setText(string text)
	{
		this.text = text;
	}
}
