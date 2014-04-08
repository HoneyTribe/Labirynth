using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	private static int levelsPerRow = 5;
	public GUISkin skin;
	public GUISkin selectedSkin;
	private LevelFinishedController levelFinishedController;
	private GameObject gameController;
	private PlayerController player2Controller;
	private int selGridInt;

	void Start()
	{
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController> ();
		selGridInt = levelFinishedController.getLevel ();
		GameObject.Find ("GameController").SendMessage ("SetMenu", this);
	}

	public void handleLogic(float x, float z, float action)
	{
		if (x > 0)
		{
			Debug.Log ("Current sel: " + selGridInt);
			if(selGridInt < levelFinishedController.getMaxLevel())
			{
				selGridInt++;
			}
			else
			{
				selGridInt = 0;
			}
			Debug.Log ("Current sel: " + selGridInt);
		}
		
		if (x < 0)
		{
			Debug.Log ("Current sel: " + selGridInt);
			if(selGridInt > 0)
			{
				selGridInt--;
			}
			else
			{
				selGridInt = levelFinishedController.getMaxLevel();
			}
			Debug.Log ("Current sel: " + selGridInt);
		}

		if (action > 0)
		{
			levelFinishedController.setLevel(selGridInt);
			Application.LoadLevel (0); 
		}
	}

	void OnGUI () 
	{
		GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 400, 300));
			GUI.Box (new Rect(0, 0, 400, 300), "", skin.box);
			GUI.Label (new Rect (0, 30, 400, 50), "Levels", skin.label);

			for (int i=0; i<=levelFinishedController.getNumberOfLevels(); i++)
			{
				int x = i % levelsPerRow;
				int y = i / levelsPerRow;
				
				if (i>levelFinishedController.getMaxLevel())
				{
					GUI.enabled = false; 
				}

				if (selGridInt == i)
				{
					GUI.Button (new Rect (50 + x * 65, 100 + y * 65, 40, 40), (i + 1).ToString(), selectedSkin.button);
				}
				else
				{
					GUI.Button (new Rect (50 + x * 65, 100 + y * 65, 40, 40), (i + 1).ToString(), skin.button);
				}

				if (i>levelFinishedController.getMaxLevel())
				{
					GUI.enabled = true; 
				}
			}	
		GUI.EndGroup();

	}
}
