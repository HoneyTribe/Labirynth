using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSelectionMenuController : MonoBehaviour {

	private const int PLAYER_IMAGE_HEIGHT = 160;

	private static int playersPerRow = 2;
	public GUISkin skin;
	public Texture2D playersTexture;

	private List<int> selGridInt = new List<int> ();

	private float blinkingTime;
	private float counter;

	private GUIStyle[] buttonStyles = new GUIStyle[4];
	private GUIStyle[] borderStyles = new GUIStyle[4];

	public GameObject menuPrefab;
	
	void Start()
	{
		LevelFinishedController.instance.getControllers().Clear();
		GameObject.Find ("GameController").SendMessage ("SetPlayerSelectionMenu", this);

		// Borders

		borderStyles[0] = new GUIStyle ();
		Texture2D border1Texture = new Texture2D (1, 1);
		border1Texture.SetPixel (0, 0, Color.green);
		border1Texture.Apply ();
		borderStyles[0].normal.background = border1Texture;

		borderStyles[1] = new GUIStyle ();
		Texture2D border2Texture = new Texture2D (1, 1);
		border2Texture.SetPixel (0, 0, Color.blue);
		border2Texture.Apply ();
		borderStyles[1].normal.background = border2Texture;

		borderStyles[2] = new GUIStyle ();
		Texture2D border3Texture = new Texture2D (1, 1);
		border3Texture.SetPixel (0, 0, Color.magenta);
		border3Texture.Apply ();
		borderStyles[2].normal.background = border3Texture;

		borderStyles[3] = new GUIStyle ();
		Texture2D border4Texture = new Texture2D (1, 1);
		border4Texture.SetPixel (0, 0, Color.yellow);
		border4Texture.Apply ();
		borderStyles[3].normal.background = border4Texture;
		
		
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
			if (!selGridInt.Contains(input.getPlayerId()))
			{
				selGridInt.Add(input.getPlayerId());
			}

			if (selGridInt.Count == LevelFinishedController.instance.getControllers().Count)
			{
				GameObject.Find ("GameController").SendMessage ("RemovePlayerSelectionMenu", null);
				Destroy(this);
				LevelFinishedController.instance.updateMaxLevel();
				Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
			}
		}
	}

	void OnGUI () 
	{
		int numberOfPlayers = LevelFinishedController.instance.getControllers ().Count;
		
		blinkingTime += Time.deltaTime;
		if (blinkingTime > 0.25f)
		{
			blinkingTime = 0;
			counter++;
			if (counter > 1)
			{
				counter = 0;
			}
		}
	
		GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 400, 300));
			GUI.Box (new Rect(0, 0, 400, 300), "", skin.box);

			for (int i=0; i<4; i++)
			{
				int x = i % playersPerRow;
				int y = i / playersPerRow;

				if (selGridInt.Contains(i+1))
				{
					GUI.enabled = false;
				}
				if ((i < numberOfPlayers) && (counter == 0) && (!selGridInt.Contains(i+1)))
				{
					GUI.Box (new Rect (100 + x * 110 - 5, 40 + y * 110 - 5, 110, 110), "", borderStyles[i]);
				}
				GUI.Button (new Rect (100 + x * 110, 40 + y * 110, 100, 100), "", buttonStyles[i]);

				if (selGridInt.Contains(i+1))
				{
					GUI.enabled = true;
				}
		}	
		GUI.EndGroup();

	}
}
