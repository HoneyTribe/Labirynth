using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelFinishedController : MonoBehaviour {

	public static bool ENABLE_ALL_LEVELS = false;
	public static float SHOW_INSTRUCTION_MIN_TIME = 0.5f;
	public static int savedMaxLevel;

	public static LevelFinishedController instance;
	public float gameSpeed = 1.0f;

	private int level = 0;
	private int maxLevel = 0;
	private AssemblyCSharp.LevelDefinition levelDefinition;

	public GameObject playerSelectionMenuPrefab;
	public GameObject menuPrefab;
	public GameObject instructionPrefab;
	public GameObject instructionPanel;
	public GUISkin LevEnd_GUISkin;
	public GUISkin help_GUISkin;
	public float instructionPanelTime;

	private List<InputController> controllers = new List<InputController> ();

	private bool finished;
	private bool gameOver;
	private bool congratulation;
	private bool stopped;

	void Awake() {
		if (instance == null) {
			// this is the first instance - make it persist
			DontDestroyOnLoad(gameObject);
			instance = this;
		} else {
			// this must be a duplicate from a scene reload - DESTROY!
			Destroy(this.gameObject);
		} 
	}
	
	void Start()
	{
		levelDefinition = new AssemblyCSharp.LevelDefinition ();
		stopped = true;
		GameObject.Find ("GameController").SendMessage ("StopIntroduction", false);
		GameObject playerSelectionMenu = (GameObject) Instantiate (playerSelectionMenuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
		playerSelectionMenu.GetComponent<PlayerSelectionMenuController>().setSplash(1);
		instructionPanelTime = Time.time;

		//retreive saved max level
		if (PlayerPrefs.HasKey("savedMaxLevel") &&  PlayerPrefs.GetInt("savedMaxLevel") > maxLevel)
		{
			maxLevel = PlayerPrefs.GetInt("savedMaxLevel");
		}
	}

	private void LoadNewLevel()
	{
		level++;

		if (level > maxLevel)
		{
			maxLevel = level;

			//save maxLevel to disk
			if (PlayerPrefs.HasKey("savedMaxLevel") && maxLevel > PlayerPrefs.GetInt("savedMaxLevel"))
			{
				PlayerPrefs.SetInt("savedMaxLevel", maxLevel);
				PlayerPrefs.Save();
			}
			else if (PlayerPrefs.HasKey("savedMaxLevel") == false)
			{
				PlayerPrefs.SetInt("savedMaxLevel", maxLevel);
				PlayerPrefs.Save();
			}
		}

		if (level > getNumberOfLevels ())
		{
			StartCoroutine(GameFinished());
		}
		else
		{
			Reset ();
			stopped = true;
			Application.LoadLevel (0); 
		}
	}

	public void Reset()
	{
		finished = false;
		gameOver = false;
		congratulation = false;
		stopped = false;
	}
	
	void OnGUI()
	{
		if (!stopped)
		{
			//GUI.Label (new Rect (Screen.width / 2 - 360, 50, 300, 300), "Level: " + (level + 1),help_GUISkin.label); 
			//GUI.Label (new Rect (Screen.width / 2 - 360, 70, 300, 300), "HELP: 'H' or 'Start'",help_GUISkin.label);
			GUI.depth = 2;
			GUI.Label (new Rect (Screen.width * 0.05f, 50, 300, 300), "Level: " + (level + 1), help_GUISkin.label); 
			GUI.Label (new Rect (Screen.width * 0.05f, 70, 300, 300), "HELP: 'H' or 'Start'", help_GUISkin.label);
			GUI.Label (new Rect (Screen.width * 0.05f, 90, 300, 300), "Version 0.1.8", help_GUISkin.label);
		}

		if (finished)
		{
			GUI.depth = 2;
			GUI.Label (new Rect (Screen.width/2 - 250, Screen.height/2 - 150, 500, 300), "Time shift initiated!" +
			" Shifting 1 earth year forward...", LevEnd_GUISkin.label);
		}
		if (gameOver)
		{
			GUI.depth = 2;
			GUI.Label (new Rect (Screen.width/2 - 250, Screen.height/2 - 150, 500, 300), "Try again",LevEnd_GUISkin.label);
		}
		if (congratulation)
		{
			GUI.depth = 2;
			GUI.Label (new Rect (Screen.width/2 - 250, Screen.height/2 - 150, 500, 300),
			"CONGRATULATIONS! YOU FINISHED THE DEMO!",LevEnd_GUISkin.label);
		}
	}

	IEnumerator PlayerFinished () 
	{
		finished = true; 
		stopped = true;
		FloorInstructions.instance.Remove();
		yield return new WaitForSeconds(4);
		finished = false; 
		LoadNewLevel();
	}

	public IEnumerator PlayerLost () 
	{
		gameOver = true; 
		stopped = true;
		FloorInstructions.instance.Remove(); // remove floor instructions
		yield return new WaitForSeconds(4);
		gameOver = false;
		Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
	}

	IEnumerator GameFinished () 
	{
		congratulation = true; 
		stopped = true;
		FloorInstructions.instance.Remove();
		yield return new WaitForSeconds(4);
		congratulation = false;
		Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
	}

	public void ShowPlayerSelectionMenu () 
	{
		GameObject playerSelectionMenu = GameObject.Find ("Player Selection Menu(Clone)");
		if ( playerSelectionMenu == null)
		{
			stopped = true;
			FloorInstructions.instance.Remove(); // remove floor instructions
			Instantiate (playerSelectionMenuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
			GameObject menu = GameObject.Find ("Menu(Clone)");
			if (menu != null)
			{
				Destroy(menu);
			}
		}
	}

	// It must be time dependent :-(
	// For keyboard: if F1 was pressed it will trigger the action 2 times, from every keyboard device 
	// For gamepad: if Start was pressed it will trigger the action 2 times, from every player using that gamepad
	public void ShowInstruction () 
	{
		if (( instructionPanel == null) && (Time.time - instructionPanelTime > SHOW_INSTRUCTION_MIN_TIME))
		{
			instructionPanel = (GameObject) Instantiate(instructionPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
			instructionPanelTime = Time.time;
		}
	}

	public bool IsInstruction () 
	{
		return (instructionPanel != null);
	}

	public void HideInstruction () 
	{
		if (( instructionPanel != null) && (Time.time - instructionPanelTime > SHOW_INSTRUCTION_MIN_TIME))
		{
			Destroy (instructionPanel);
			instructionPanelTime = Time.time;
		}
	}

	public int getNumberOfKeys()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getNumberOfKeys();
	}

	public List<AssemblyCSharp.MonsterTemplate> getMonsters()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getMonsters ();
	}

	public int getTimeToFirstMonster()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getTimeToFirstMonster ();
	}

	public int getTimeBetweenMonsters()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getTimeBetweenMonsters ();
	}

	public int getMazeSizeX()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getMazeSizeX ();
	}

	public int getMazeSizeZ()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getMazeSizeZ ();
	}
	
	public string getEnding()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getEnding ();
	}

	public string getPuzzleName()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getPuzzleName ();
	}

	public bool isDistractionEnabled()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getMachineCreator().isDistractionEnabled();
	}

	public bool isItemActivationEnabled()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getMachineCreator().isItemActivationEnabled();
	}

	public bool isPickingUpEnabled()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getMachineCreator().isPickingUpEnabled();
	}
	
	public bool isSmashingEnabled()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getMachineCreator().isSmashingEnabled();
	}

	public bool isTeleportEnabled()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getMachineCreator().isTeleportEnabled();
	}
	
	public bool isStunGunEnabled()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getMachineCreator().isStunGunEnabled();
	}

	public int getFirstLevelWithLight ()
	{
		return levelDefinition.getFirstLevelWithLight ();
	}
	
	public bool isStopped()
	{
		return stopped;
	}

	public int getMaxLevel()
	{
		return maxLevel;
	}

	public void updateMaxLevel()
	{
		if (ENABLE_ALL_LEVELS)
		{
			maxLevel = getNumberOfLevels ();
		}
	}

	public int getLevel()
	{
		return level;

	}

	public int getNumberOfLevels()
	{
		return  levelDefinition.getLevels (controllers.Count).Count - 1;
	}

	public void setLevel(int newLevel)
	{
		level = newLevel;
	}

	public List<InputController> getControllers()
	{
		return controllers;
	}
}
