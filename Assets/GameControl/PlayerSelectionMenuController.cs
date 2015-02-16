using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSelectionMenuController : MonoBehaviour {

	private const int PLAYER_IMAGE_HEIGHT = 160;
	private float iconSize = 160;
	private string version = "0.1.9";
	private string url = "http://www.honeytribestudios.com/games1/BFF/bffVersion.txt";
	private string versionRead;
	private int randomNum = 1;

	private static int playersPerRow = 2;
	public GUISkin skin;
	public GUISkin selectedSkin;
	public GUISkin error_GUIskin;
	public GUISkin neutral_GUIskin;
	public GUISkin neutralSelected_GUIskin;
	public GUISkin pinkButton_GUIskin;
	public Texture2D playersTexture;
	public Texture2D padTexture;
	public Texture2D keyboardTexture;
	public Texture2D mainSplashTexture;	

	private List<PlayerSelectionState> selGridInt = new List<PlayerSelectionState> ();

	private GUIStyle[] buttonStyles = new GUIStyle[4];

	private GUIStyle mainSplashStyle = new GUIStyle();
	private GUIStyle mainBackgroundStyle = new GUIStyle();
	private int splash = 0;
	private GUIStyle outerStyle;

	public GameObject menuPrefab;
	public GameObject instructionPrefab;
	private GameObject instructionPanel;

	void Start()
	{
		LevelFinishedController.instance.getControllers().Clear();
		GameObject.Find ("GameController").SendMessage ("SetPlayerSelectionMenu", this);

		// Buttons
		buttonStyles = SpritesLoader.getPlayerSprites (playersTexture);

		// main splash
		mainSplashStyle.normal.background = mainSplashTexture;
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,Color.black);
		texture.Apply();
		mainBackgroundStyle.normal.background = texture;

		//black background, full screen
		outerStyle = new GUIStyle ();
		Texture2D outerTexture = new Texture2D (1, 1);
		outerTexture.SetPixel (0, 0, Color.black);
		outerTexture.Apply ();
		outerStyle.normal.background = outerTexture;

		//get version from server
		WWW www = new WWW(url);			
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		versionRead = www.text;
	}

	public void handleLogic(float x, float z, float action, float action2, InputController input)
	{
		if ((action > 0) || (action2 > 0) )
		{
			if (this.instructionPanel != null) 
			{
				Destroy (instructionPanel);
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
				if ((selGridInt.Count > 1) && (state.getPositionInMenu() == PlayerSelectionState.START))
				{
					AudioController.instance.Play("003_CollectKey");
					GameObject.Find ("GameController").SendMessage ("RemovePlayerSelectionMenu", null);
					Destroy(gameObject);
					LevelFinishedController.instance.updateMaxLevel();
					Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));

				}
				if (state.getPositionInMenu() == PlayerSelectionState.HELP)
				{
					AudioController.instance.Play("003_CollectKey");
					this.instructionPanel = (GameObject) Instantiate (instructionPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
				}
				if (state.getPositionInMenu() == PlayerSelectionState.VERSION && version != versionRead && versionRead !="")
				{
					AudioController.instance.Play("003_CollectKey");
					Application.OpenURL("http://tiny.cc/bffnew");
				}
				if (state.getPositionInMenu() == PlayerSelectionState.TWEET1 && versionRead !="")
				{
					AudioController.instance.Play("003_CollectKey");
					randomNum = Random.Range(1,7);
					// 1 = Polaris, 2 = CutePieMarzia, 3 = Stumpt, 4 = Hat Films, 5 = PewDiePie, 6 = the fine bros
					Application.OpenURL("https://tiny.cc/bfftweet"+randomNum);
				}
				if (state.getPositionInMenu() == PlayerSelectionState.YOUTUBE && versionRead !="")
				{
					AudioController.instance.Play("003_CollectKey");
					randomNum = Random.Range(1,7);
					// 1 = i53 Fri, 2 = i53 Sat, 3 = Pixel Rogues, 4 = Team Banana, 5 = RazorSharp, 6 = Eneh (scaredgirl),
					// 7 = purity sinners
					Application.OpenURL("https://tiny.cc/bfftube"+randomNum);
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
		if (splash == 1)
		{
			GUI.depth = 0;
			float height = Screen.width * 900/1600;
			GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height ), mainBackgroundStyle);
			GUI.Box (new Rect(0, (Screen.height - height)/2, Screen.width, height), "", mainSplashStyle);
			GUI.EndGroup();
		}
		else if (splash == 2)
		{
			//handled in setSplash method
		}
		else
		{

			float height = Screen.width * 720/1280;
			int textHeight = 40;

			//GUI.BeginGroup(new Rect(0 ,(Screen.height - height)/2, Screen.width, height));
			//GUI.Box (new Rect(0, 0, Screen.width, height), "", skin.box);

			GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height), "", outerStyle );
			GUI.Box (new Rect(0 ,(Screen.height - height)/2, Screen.width, height), "", skin.box);


				for (int i=0; i<4; i++)
				{
					int x = i % playersPerRow;
					int y = i / playersPerRow;
					

					if (getSelectedGrid(i+1) == null)
					{
						GUI.enabled = false;
					}

					//GUI.Button (new Rect (110 + x * 100, 60 + y * 100, 90, 90), "", buttonStyles[i]);
					float screenScale = Screen.width/1280f;
					GUI.Button (new Rect (Screen.width/2 - (screenScale * iconSize) + (x * screenScale * iconSize),
				    (Screen.height - height)/2 + height*0.18f + (y * iconSize * screenScale),
				    screenScale * iconSize, screenScale * iconSize), "", buttonStyles[i]);

					if (getSelectedGrid(i+1) == null)
					{
						GUI.enabled = true;
					}
				}					

				if (isAnyCursorOn(PlayerSelectionState.START))
				{
					if (selGridInt.Count < 2)
					{
					GUI.Label(new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.69f - (textHeight/2), 360, textHeight),
					"Select at least 2 characters", error_GUIskin.label);
					}
					else
					{
					GUI.Button (new Rect (Screen.width/2 - (120/2), (Screen.height - height)/2 + height * 0.69f - (textHeight/2), 120, textHeight),
					"Start", selectedSkin.button);
					}
				}
				else
				{
					if (selGridInt.Count < 2)
					{
					//GUI.Label(new Rect (30, 260, 340, 40), "Select at least 2 players", skin.button);
					GUI.Label(new Rect (Screen.width/2 - (280/2), (Screen.height - height)/2 + height * 0.69f - (textHeight/2), 280, textHeight),
					 "Select at least 2 characters", skin.button);
					}
					else
					{
					GUI.Button (new Rect (Screen.width/2 - (100/2), (Screen.height - height)/2 + height * 0.69f - (textHeight/2), 100, textHeight),
					"Start", skin.button);
					}
				}
				if (isAnyCursorOn(PlayerSelectionState.HELP))
				{
					GUI.Button (new Rect (Screen.width/2 - (140/2), (Screen.height - height)/2 + height * 0.70f - (textHeight/2) + textHeight, 140, textHeight),
					            "Controls", selectedSkin.button);
				}
				else
				{
					GUI.Button (new Rect (Screen.width/2 - (120/2), (Screen.height - height)/2 + height * 0.70f - (textHeight/2) + textHeight, 120, textHeight),
					            "Controls",skin.button);
				}
				//internet connection
				if(versionRead != "")
				{

					if (isAnyCursorOn(PlayerSelectionState.TWEET1))
					{
					GUI.Button (new Rect (Screen.width/2 - (390/2), (Screen.height - height)/2 + height * 0.765f - (textHeight/2) + textHeight, 390, textHeight),
					"Ask youtubers to play BFF or Die!", selectedSkin.button);
					}
					else
					{
					GUI.Button (new Rect (Screen.width/2 - (320/2), (Screen.height - height)/2 + height * 0.765f - (textHeight/2) + textHeight, 320, textHeight),
					 "Ask youtubers to play BFF or Die!",skin.button);
					}

					if (isAnyCursorOn(PlayerSelectionState.YOUTUBE))
					{
					GUI.Button (new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.83f - (textHeight/2) + textHeight, 360, textHeight),
					"Watch BFF or Die on Youtube", selectedSkin.button);
					}
					else
					{
					GUI.Button (new Rect (Screen.width/2 - (320/2), (Screen.height - height)/2 + height * 0.83f - (textHeight/2) + textHeight, 320, textHeight),
					 "Watch BFF or Die on Youtube",skin.button);
					}

					if(versionRead != version) // local version is old
					{
						if (isAnyCursorOn(PlayerSelectionState.VERSION))
						{
							GUI.Button (new Rect (Screen.width/2 - (300/2), (Screen.height - height)/2 + height * 0.90f - (textHeight/2) + textHeight, 300, textHeight),
							 "Get the shiny new update!",selectedSkin.button);
						}
						else
						{
							GUI.Button (new Rect (Screen.width/2 - (280/2), (Screen.height - height)/2 + height * 0.90f - (textHeight/2) + textHeight, 280, textHeight),
						    "Get the shiny new update!",pinkButton_GUIskin.button);
						}
					}
					
					else if (version == versionRead) //local version is newest
					{
						if(isAnyCursorOn(PlayerSelectionState.VERSION))
						{
							GUI.Label (new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.90f - (textHeight/2) + textHeight, 360, textHeight),
							"You have the latest version "+version, neutralSelected_GUIskin.label);
						}
						else
						{
							GUI.Label (new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.90f - (textHeight/2) + textHeight, 360, textHeight),
						     "You have the latest version " + version, neutral_GUIskin.label);
						}
					}
				}
				//no internet
				else
				{
					if (isAnyCursorOn(PlayerSelectionState.TWEET1))
					{
						GUI.Button (new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.765f - (textHeight/2) + textHeight, 360, textHeight),
					     "No connection", neutralSelected_GUIskin.label);
					}
					else
					{
						GUI.Button (new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.765f - (textHeight/2) + textHeight, 360, textHeight),
					     "No connection",neutral_GUIskin.label);
					}
					
					if (isAnyCursorOn(PlayerSelectionState.YOUTUBE))
					{
						GUI.Button (new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.83f - (textHeight/2) + textHeight, 360, textHeight),
					     "No connection", neutralSelected_GUIskin.label);
					}
					else
					{
						GUI.Button (new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.83f - (textHeight/2) + textHeight, 360, textHeight),
					    "Can't connect to the internet",neutral_GUIskin.label);
					}

					if(isAnyCursorOn(PlayerSelectionState.VERSION))
					{
						GUI.Label (new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.90f - (textHeight/2) + textHeight, 360, textHeight),
						 "Can't check for updates",neutralSelected_GUIskin.label);
					}
					else
					{
						GUI.Label (new Rect (Screen.width/2 - (360/2), (Screen.height - height)/2 + height * 0.90f - (textHeight/2) + textHeight, 360, textHeight),
						"No connection. Can't check for updates",neutral_GUIskin.label);
					}
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

	public void setSplash(int splash)
	{
		this.splash = splash;
		if (splash > 0)

		{
			selGridInt.Clear(); 
		}

		if (this.instructionPanel != null) 
		{
			Destroy (this.instructionPanel);
		}
		if (splash == 2)
		{
			this.instructionPanel = (GameObject) Instantiate (instructionPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
		}
	}

	public int getSplash()
	{
		return this.splash;
	}
}
