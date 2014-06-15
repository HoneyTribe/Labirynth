using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	private static int levelsPerRow = 5;
	public GUISkin skin;
	public GUISkin selectedSkin;
	private GameObject gameController;
	private int selGridInt;

	void Start()
	{
		selGridInt = LevelFinishedController.instance.getLevel ();
		foreach (InputController input in LevelFinishedController.instance.getControllers())
		{
			input.SetMenu(this);
		}
	}

	public void handleLogic(float x, float z, float action, float action2)
	{
		if (x > 0)
		{
			if(selGridInt < LevelFinishedController.instance.getMaxLevel())
			{
				selGridInt++;
			}
			else
			{
				selGridInt = 0;
			}
		}
		
		if (x < 0)
		{
			if(selGridInt > 0)
			{
				selGridInt--;
			}
			else
			{
				selGridInt = LevelFinishedController.instance.getMaxLevel();
			}
		}

		if ((action > 0) || (action2 > 0))
		{
			LevelFinishedController.instance.setLevel(selGridInt);
			AudioController.instance.Play("003_CollectKey");
			Application.LoadLevel (0); 
		}
	}

	void OnGUI () 
	{
		GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 400, 300));
			GUI.Box (new Rect(0, 0, 400, 300), "", skin.box);
			GUI.Label (new Rect (0, 30, 400, 50), "Levels", skin.label);

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
					GUI.Button (new Rect (50 + x * 65, 80 + y * 65, 40, 40), (i + 1).ToString(), selectedSkin.button);
				}
				else
				{
					GUI.Button (new Rect (50 + x * 65, 80 + y * 65, 40, 40), (i + 1).ToString(), skin.button);
				}

				if (i>LevelFinishedController.instance.getMaxLevel())
				{
					GUI.enabled = true; 
				}
			}	
		GUI.EndGroup();

	}
}
