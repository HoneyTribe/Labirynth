using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MenuController : MonoBehaviour {

	private static int levelsPerRow = 5;
	public GUISkin skin;
	public GUISkin selectedSkin;
	public Texture2D background;
	private GameObject gameController;
	private int selGridInt;
	private GUIStyle backgroundStyle = new GUIStyle();
	private GUIStyle outerStyle;

	void Start()
	{
		selGridInt = LevelFinishedController.instance.getLevel ();
		foreach (InputController input in LevelFinishedController.instance.getControllers())
		{
			input.SetMenu(this);
		}
		backgroundStyle.normal.background = background;

		//black background, full screen
		outerStyle = new GUIStyle ();
		Texture2D outerTexture = new Texture2D (1, 1);
		outerTexture.SetPixel (0, 0, Color.black);
		outerTexture.Apply ();
		outerStyle.normal.background = outerTexture;
	}

	public void handleLogic(float x, float z, float action, float action2)
	{
		// fix gamepad diagonal behaviour
		if ((x != 0) && (z != 0))
		{
			if (Math.Abs(x) > Math.Abs (z))
			{
				z = 0;
			}
			else
			{
				x = 0;
			}
		}

		if (x > 0)
		{
			if ((selGridInt + 1) % levelsPerRow == 0)
			{
				selGridInt -= levelsPerRow - 1;
			}
			else if (selGridInt + 1 > LevelFinishedController.instance.getMaxLevel())
			{
				selGridInt = (LevelFinishedController.instance.getMaxLevel() / levelsPerRow) * levelsPerRow;
			}
			else
			{
				selGridInt++;
			}
		}
		
		if (x < 0)
		{	
			if(selGridInt % levelsPerRow == 0)
			{
				selGridInt += levelsPerRow - 1;
				if (selGridInt > LevelFinishedController.instance.getMaxLevel())
				{
					selGridInt = LevelFinishedController.instance.getMaxLevel();
				}
			}
			else
			{
				selGridInt--;
			}
		}

		if (z < 0)
		{	
			if(selGridInt + levelsPerRow <= LevelFinishedController.instance.getMaxLevel())
			{
				selGridInt += levelsPerRow;
			}
			else
			{
				selGridInt = selGridInt % levelsPerRow;
			}
		}

		if (z > 0)
		{
			if(selGridInt - levelsPerRow < 0)
			{
				int posInRow = selGridInt % levelsPerRow;
				int numberOfRows = LevelFinishedController.instance.getMaxLevel() / levelsPerRow;
				selGridInt = numberOfRows * levelsPerRow + posInRow;
				if (selGridInt > LevelFinishedController.instance.getMaxLevel())
				{
					selGridInt -= levelsPerRow;
				}
			}
			else
			{
				selGridInt -= levelsPerRow;
			}
		}


		if ((action > 0) || (action2 > 0))
		{
			//AudioController.instance.Play("003_CollectKey");
			LevelFinishedController.instance.setLevel(selGridInt);
			LevelFinishedController.instance.LevelCounter();
			Application.LoadLevel (0); 
		}
	}

	void OnGUI () 
	{
		//GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 300, 600, 600));
			//GUI.Box (new Rect(0, 0, 600, 600), "", backgroundStyle);
			//GUI.Label (new Rect (100, 165, 400, 50), "Levels", skin.label);

		float x1 = Screen.width / 2 - 300;
		float y1 =Screen.height / 2 - 300;

		GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height), "", outerStyle );
		GUI.Box (new Rect(x1, y1-40, 600, 600), "", backgroundStyle);
		GUI.Label (new Rect (x1 + 100, y1 + 160, 400, 50), "Levels", skin.label);

			for (int i=0; i<=LevelFinishedController.instance.getNumberOfLevels(); i++)
			{
				int x = i % levelsPerRow;
				int y = i / levelsPerRow;
				
				if (i>LevelFinishedController.instance.getMaxLevel())
				{
					GUI.enabled = false; 
				}

				if (selGridInt == i)
				{
				GUI.Button (new Rect (x1 +160 + x * 59, y1 + 210 + y * 55, 40, 40), (i + 1).ToString(), selectedSkin.button);
				}
				else
				{
				GUI.Button (new Rect (x1 +160 + x * 59, y1 + 210 + y * 55, 40, 40), (i + 1).ToString(), skin.button);
				}

				if (i>LevelFinishedController.instance.getMaxLevel())
				{
					GUI.enabled = true; 
				}
			}	
		GUI.EndGroup();

	}
}
