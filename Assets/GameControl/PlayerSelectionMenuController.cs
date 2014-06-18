using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSelectionMenuController : MonoBehaviour {

	private const int PLAYER_IMAGE_HEIGHT = 160;

	private static int playersPerRow = 2;
	public GUISkin skin;
	public GUISkin selectedSkin;
	public Texture2D playersTexture;

	private List<PlayerSelectionState> selGridInt = new List<PlayerSelectionState> ();

	private GUIStyle[] buttonStyles = new GUIStyle[4];

	public GameObject menuPrefab;
	
	void Start()
	{
		LevelFinishedController.instance.getControllers().Clear();
		GameObject.Find ("GameController").SendMessage ("SetPlayerSelectionMenu", this);

		// Buttons
		buttonStyles = SpritesLoader.getPlayerSprites (playersTexture);
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
			PlayerSelectionState state = getSelectedGrid(input.getPlayerId());
			if (state == null)
			{
				selGridInt.Add(new PlayerSelectionState(input.getPlayerId()));
				AudioController.instance.Play("003_CollectKey");
			}
			else
			{
				if (state.isCursorOnStart())
				{
					GameObject.Find ("GameController").SendMessage ("RemovePlayerSelectionMenu", null);
					Destroy(gameObject);
					LevelFinishedController.instance.updateMaxLevel();
					Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
				}
			}
		}

		if (z < 0)
		{
			getSelectedGrid(input.getPlayerId()).moveCursorOnStart();
		}

		if (z > 0)
		{
			getSelectedGrid(input.getPlayerId()).moveCursorOutOfStart();
		}
	}

	void OnGUI () 
	{
		int numberOfPlayers = LevelFinishedController.instance.getControllers ().Count;
		
		GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 400, 300));
			GUI.Box (new Rect(0, 0, 400, 300), "", skin.box);

			for (int i=0; i<4; i++)
			{
				int x = i % playersPerRow;
				int y = i / playersPerRow;

				if (getSelectedGrid(i+1) == null)
				{
					GUI.enabled = false;
				}

				GUI.Button (new Rect (110 + x * 100, 30 + y * 100, 90, 90), "", buttonStyles[i]);

				if (getSelectedGrid(i+1) == null)
				{
					GUI.enabled = true;
				}
			}	
			
			if (isAnyCursorOnStart())
			{
				GUI.Button (new Rect (155, 230, 100, 40), "Start", selectedSkin.button);
			}
			else
			{
				GUI.Button (new Rect (155, 230, 100, 40), "Start", skin.button);
			}
		GUI.EndGroup();

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

	private bool isAnyCursorOnStart()
	{
		foreach(PlayerSelectionState state in selGridInt)
		{
			if (state.isCursorOnStart())
			{
				return true;
			}
		}
		
		return false;
	}
}
