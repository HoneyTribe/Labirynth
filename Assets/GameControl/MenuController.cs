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

	void Start()
	{
		selGridInt = LevelFinishedController.instance.getLevel ();
		foreach (InputController input in LevelFinishedController.instance.getControllers())
		{
			input.SetMenu(this);
		}
		backgroundStyle.normal.background = background;
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
			LevelFinishedController.instance.setLevel(selGridInt);
			Application.LoadLevel (0); 
		}
	}

	void OnGUI () 
	{
		GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 300, 600, 600));
			GUI.Box (new Rect(0, 0, 600, 600), "", backgroundStyle);
			GUI.Label (new Rect (100, 165, 400, 50), "Levels", skin.label);

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
					GUI.Button (new Rect (160 + x * 59, 210 + y * 55, 40, 40), (i + 1).ToString(), selectedSkin.button);
				}
				else
				{
					GUI.Button (new Rect (160 + x * 59, 210 + y * 55, 40, 40), (i + 1).ToString(), skin.button);
				}

				if (i>LevelFinishedController.instance.getMaxLevel())
				{
					GUI.enabled = true; 
				}
			}	
		GUI.EndGroup();

	}
}
