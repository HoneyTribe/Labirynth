﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSelectionMenuController : MonoBehaviour {

	private const int PLAYER_IMAGE_HEIGHT = 160;

	private static int playersPerRow = 2;
	public GUISkin skin;
	public GUISkin selectedSkin;
	public Texture2D playersTexture;
	public Texture2D padTexture;
	public Texture2D keyboardTexture;

	private List<PlayerSelectionState> selGridInt = new List<PlayerSelectionState> ();

	private GUIStyle[] buttonStyles = new GUIStyle[4];
	private GUIStyle padStyle = new GUIStyle();
	private GUIStyle keyboardStyle = new GUIStyle();
	private GUIStyle instructionstyle = null;

	public GameObject menuPrefab;

	void Start()
	{
		LevelFinishedController.instance.getControllers().Clear();
		GameObject.Find ("GameController").SendMessage ("SetPlayerSelectionMenu", this);

		// Buttons
		buttonStyles = SpritesLoader.getPlayerSprites (playersTexture);

		padStyle.normal.background = padTexture;
		keyboardStyle.normal.background = keyboardTexture;
	}

	public void handleLogic(float x, float z, float action, float action2, InputController input)
	{
//		if ((x > 0) && (selGridInt < 2))
//		{
//			selGridInt++;
//		}
//		
//		if ((x < 0) && (selGridInt >= 0))
//		{
//			selGridInt--;
//		}
//
//		if ((z > 0) && (selGridInt < 2))
//		{
//			selGridInt += 2;
//		}
//		
//		if ((z < 0) && (selGridInt >= 2))
//		{
//			selGridInt -= 2;
//		}
		
		if ((action > 0) || (action2 > 0))
		{
			if (this.instructionstyle != null) 
			{
				this.instructionstyle = null;
				return;
			}

			PlayerSelectionState state = getSelectedGrid(input.getPlayerId());
			if (state == null)
			{
				selGridInt.Add(new PlayerSelectionState(input.getPlayerId()));
				AudioController.instance.Play("003_CollectKey");
			}
			else
			{
				if (state.getPositionInMenu() == PlayerSelectionState.START)
				{
					GameObject.Find ("GameController").SendMessage ("RemovePlayerSelectionMenu", null);
					Destroy(gameObject);
					LevelFinishedController.instance.updateMaxLevel();
					Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
				}
				if (state.getPositionInMenu() == PlayerSelectionState.HELP)
				{
					if (input.isKeyboard())
					{
						this.instructionstyle = keyboardStyle;
					}
					else
					{
						this.instructionstyle = padStyle;
					}
				}
			}
		}

		if (z < 0)
		{
			getSelectedGrid(input.getPlayerId()).moveCursorDown();
		}

		if (z > 0)
		{
			getSelectedGrid(input.getPlayerId()).moveCursorUp();
		}
	}

	void OnGUI () 
	{
		int numberOfPlayers = LevelFinishedController.instance.getControllers ().Count;

		if (this.instructionstyle != null)
		{
			float height = 800f/1280f*(Screen.width-200);
			float half = (Screen.height - height)/2;
			GUI.BeginGroup(new Rect(100, half, Screen.width-100, Screen.height - half ));
				GUI.Box (new Rect(0, 0, Screen.width-200, height), "", instructionstyle);
			GUI.EndGroup();
		} 
		else
		{
			GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400));
				GUI.Box (new Rect(0, 0, 400, 400), "", skin.box);

				for (int i=0; i<4; i++)
				{
					int x = i % playersPerRow;
					int y = i / playersPerRow;

					if (getSelectedGrid(i+1) == null)
					{
						GUI.enabled = false;
					}

					GUI.Button (new Rect (110 + x * 100, 60 + y * 100, 90, 90), "", buttonStyles[i]);

					if (getSelectedGrid(i+1) == null)
					{
						GUI.enabled = true;
					}
				}	
				
				if (isAnyCursorOn(PlayerSelectionState.START))
				{
					GUI.Button (new Rect (140, 260, 120, 40), "Start", selectedSkin.button);
				}
				else
				{
					GUI.Button (new Rect (140, 260, 120, 40), "Start", skin.button);
				}

				if (isAnyCursorOn(PlayerSelectionState.HELP))
				{
					GUI.Button (new Rect (140, 310, 120, 40), "Controls", selectedSkin.button);
				}
				else
				{
					GUI.Button (new Rect (140, 310, 120, 40), "Controls", skin.button);
				}
			GUI.EndGroup();
		}

	}

	private PlayerSelectionState getSelectedGrid(int id)
	{
		foreach(PlayerSelectionState state in selGridInt)
		{
			if (state.getId() == id)
			{
				return state;
			}
		}

		return null;
	}

	private bool isAnyCursorOn(int desiredState)
	{
		foreach(PlayerSelectionState state in selGridInt)
		{
			if (state.getPositionInMenu() == desiredState)
			{
				return true;
			}
		}
		
		return false;
	}
}
