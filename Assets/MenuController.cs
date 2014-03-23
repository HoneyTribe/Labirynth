using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	private static int levelsPerRow = 5;
	public GUISkin skin;
	private LevelFinishedController levelFinishedController;

	private int selGridInt = 0;
	
	private List<string> selStrings = new List<string>();

	void Start()
	{
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController> ();
		for (int i=0; i<=levelFinishedController.getMaxLevel(); i++)
		{
			selStrings.Add((i + 1).ToString());
		}
	}

	void Update()
	{
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			if(selGridInt < levelFinishedController.getMaxLevel())
			{
				selGridInt++;
			}
			else
			{
				selGridInt = 0;
			}
		}
		
		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			if(selGridInt > 0)
			{
				selGridInt--;
			}
			else
			{
				selGridInt = levelFinishedController.getMaxLevel();
			}
		}

		if(Input.GetKeyUp(KeyCode.RightShift))
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

			int numOfLines = (selStrings.Count - 1) / levelsPerRow + 1;
			selGridInt = GUI.SelectionGrid (new Rect (30, 100, 340, numOfLines * 50), selGridInt, selStrings.ToArray(), levelsPerRow, skin.button);
//			for (int i=0; i<=levelFinishedController.getMaxLevel(); i++)
//			{
//				int x = i % levelsPerRow;
//				int y = i / levelsPerRow;
//				if (GUI.Button (new Rect (50 + x * 65, 100 + y * 65, 40, 40), (i + 1).ToString(), skin.button))
//				{
//					levelFinishedController.setLevel(i);
//					Application.LoadLevel (0); 
//				}
//			}	
		GUI.EndGroup();

	}
}
