using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelFinishedController : MonoBehaviour {
	
	public static bool ENABLE_ALL_LEVELS = false;
	public static float SHOW_INSTRUCTION_MIN_TIME = 0.3f;
	public static int savedMaxLevel;
	private int bootups = 0;
	private int totalLevels = 35;
	private int levCount = 0;
	private int[] attempt; //amount of times died on same level
	private int dynamicDifficulty = 1; //turns on/off dynamic difficulty
	private int attemptsForChange = 3; // number of deaths on one level before dynamic difficulty is activated.
	private int delay = 1; //time added to each monster spawn if dynamic difficulty is active.
	private int delayMax = 3;
	private int analytics = 0; // tuns on/off. send data to analytics server
	private int unlock = 1; // turns on/off. press "l" to toggle unlocked and locked levels
	private int homeVersion = 1; // turns on /off. loads max saved level from disk and saved deadCount
	private int deadCount = 0; // number of times a character is paralysed
	private int menuCount = 0; //number of times menu visited in current session
	
	public static LevelFinishedController instance;
	public float gameSpeed = 1.0f;
	
	private int level = 0;
	private int maxLevel = 0;
	private int[] levelsCounter;
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
	
	private bool decoyFixed;

	void Awake()
	{
		if (instance == null)
		{
			// this is the first instance - make it persist
			DontDestroyOnLoad(gameObject);
			instance = this;
			Application.LoadLevel(0);
			
			//hide mouse curser
			Screen.showCursor = false;
			
			//load bootups from disk and save
			if (PlayerPrefs.HasKey("Savedbootups"))
			{
				bootups = PlayerPrefs.GetInt("Savedbootups") + 1;
				PlayerPrefs.SetInt("Savedbootups", bootups);
				PlayerPrefs.Save();
				//send to analytics
				if(analytics ==1)
				{
				GA.API.Design.NewEvent("Bootups", 1);
				}
			}
			else
			{
				bootups++;
				PlayerPrefs.SetInt("Savedbootups", bootups);
				PlayerPrefs.Save();
				//send to analytics
				if(analytics ==1)
				{
				GA.API.Design.NewEvent("Bootups",1);
				}
			}
		}
		
		else 
		{
			// this must be a duplicate from a scene reload - DESTROY!
			Destroy(this.gameObject);
		} 
	}
	
	void Start()
	{
		levelDefinition = new AssemblyCSharp.LevelDefinition ();
		stopped = false;
		if (GameObject.Find ("GameController").GetComponent<IntroductionController>() != null)
		{
			GameObject.Find ("GameController").SendMessage ("StopIntroduction", false);
		}
		instructionPanelTime = Time.time;
		levelsCounter = new int[totalLevels];
		attempt = new int[totalLevels];
		
		if (bootups == 1) //set all levelsCounter values to 0
		{
			for(int i = 0; i < totalLevels; i++)
			{
				levelsCounter[i]=0;
			}
		}
		
		else //load levelsCounter
		{
			for(int i = 0; i < totalLevels; i++)
			{
				if(PlayerPrefs.HasKey("savedLevelsCounter"+i))
				{
					levelsCounter[i]= PlayerPrefs.GetInt("savedLevelsCounter"+i);
				}
			}
		}

		if(homeVersion == 1)
		{
			//retreive saved max level
			if (PlayerPrefs.HasKey("savedMaxLevel") &&  PlayerPrefs.GetInt("savedMaxLevel") > maxLevel)
			{
				maxLevel = PlayerPrefs.GetInt("savedMaxLevel");
			}

			//retreive deadCount
			if (PlayerPrefs.HasKey("savedDeadCount"))
			{
				deadCount = PlayerPrefs.GetInt("savedDeadCount");
			}

			//have max level ready to play on startup
			if(Application.loadedLevel == 0)
			{
				menuCount++;
				
				if(menuCount == 1)
				{
					level = maxLevel;
				}
			}
		}

		//retreive levCount
		levCount = PlayerPrefs.GetInt("savedLevCount");

		//unlock levels if needed
		updateMaxLevel();

	}


	void Update()
	{
		if(unlock == 1)
		{
			if (Input.GetKeyDown("l"))
			{
				if(ENABLE_ALL_LEVELS == true)
				{
					ENABLE_ALL_LEVELS = false;
					maxLevel = 0;
					level = 0;
					AudioController.instance.Play("003_CollectKey");
				}
				else
				{
					ENABLE_ALL_LEVELS = true;
					maxLevel = totalLevels-1;
					AudioController.instance.Play("003_CollectKey");
				}
			}
		}
	}

	
	private void LoadNewLevel()
	{
			level++;
		

		if (level > maxLevel && level < getNumberOfLevels() )
		{
			maxLevel = level;
			
			//save maxLevel to disk
			if (PlayerPrefs.HasKey("savedMaxLevel") && maxLevel > PlayerPrefs.GetInt("savedMaxLevel"))
			{
				PlayerPrefs.SetInt("savedMaxLevel", maxLevel);
				PlayerPrefs.Save();
				//send to analytics
				if(analytics ==1)
				{
				GA.API.Design.NewEvent("maxLevel"+maxLevel,1);
				}
			}
			else if (PlayerPrefs.HasKey("savedMaxLevel") == false)
			{
				PlayerPrefs.SetInt("savedMaxLevel", maxLevel);
				PlayerPrefs.Save();
				//send to analytics
				if(analytics ==1)
				{
				GA.API.Design.NewEvent("maxLevel"+maxLevel,1);
				}
			}
		}
		
		if (level > getNumberOfLevels() )
		{
			level = getNumberOfLevels();
			StartCoroutine(GameFinished() );
		}
		else
		{
			LevelCounter();
			//Reset ();
			stopped = true;
			finished = false;
			Application.LoadLevel (1); 
		}
	}
	
	public void Reset()
	{
		finished = false;
		gameOver = false;
		congratulation = false;
		stopped = false;
	}
	
	//triggered from this script and PlayerSelectionMenuController
	public void LevelCounter()
	{
		levCount++;
		PlayerPrefs.SetInt("savedLevCount", levCount);
		if(analytics ==1)
		{
		GA.API.Design.NewEvent("totalLevelsPlayed", 1);
		}
		
		//send levelCounter to analytics
		levelsCounter[level]++;
		if(analytics ==1)
		{
		GA.API.Design.NewEvent("levelsCounter" + level, 1);
		}
		//save levelCouner to disk
		PlayerPrefs.SetInt("savedLevelsCounter"+level, levelsCounter[level]);
		PlayerPrefs.Save();
	}
	
	void OnGUI()
	{
		if (Application.loadedLevel != 0 )
		{
			if (!stopped && IntroductionController.instance.isPlayingIntroduction()== false &&
			    ScoreController.instance.getScore() > 0 && ScoreController.instance.getNumberOfPlayers() > 0)
			{
				GUI.depth = 2;
				GUI.Label (new Rect (Screen.width * 0.05f, 70, 300, 300), "Zone " + (level + 1), help_GUISkin.label); 
				GUI.Label (new Rect (Screen.width * 0.05f, 90, 300, 300), "Help: 'Start' or 'Enter'", help_GUISkin.label);
				GUI.Label (new Rect (Screen.width * 0.05f, 110, 300, 300), "Quit: 'Back' or 'Escape'", help_GUISkin.label);
			}
		}
		if (finished && level < totalLevels-1)
		{
			GUI.depth = 2;
			GUI.Label (new Rect (Screen.width/2 - 250, Screen.height/2 - 150, 500, 300), "Time shift initiated!" +
			           " Travelling " + levelDefinition.getLevels(controllers.Count)[level].getNumberOfKeys() + " earth years forward...", LevEnd_GUISkin.label);
		}
		if (finished && level == totalLevels-1 && !congratulation)
		{
			GUI.depth = 2;
			GUI.Label (new Rect (Screen.width/2 - 250, Screen.height/2 - 150, 500, 300),
			           "Congratulations!",LevEnd_GUISkin.label);
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
			           "Time-shifting 3000 years... soon. Continue the adventure in a future update!",LevEnd_GUISkin.label);
		}
	}
	
	IEnumerator PlayerFinished () 
	{
		finished = true; 
		stopped = true;
		
		attempt[level] = 0;
		//PlayerPrefs.SetInt("savedAttempt"+level, attempt[level]);
		//PlayerPrefs.Save();
		
		FloorInstructions.instance.Remove();
		LevelEnd.instance.LevEnd();
		yield return new WaitForSeconds(4);
		LoadNewLevel();
	}
	
	public IEnumerator PlayerLost () 
	{
		gameOver = true; 
		stopped = true;
		
		attempt[level]++;
		//PlayerPrefs.SetInt("savedAttempt"+level, attempt[level]);
		//PlayerPrefs.Save();
		
		FloorInstructions.instance.Remove(); // remove floor instructions
		yield return new WaitForSeconds(4);
		//Reset();
		finished = false;
		gameOver = false;
		Application.LoadLevel (1); 
		//Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
	}
	
	IEnumerator GameFinished () 
	{
		congratulation = true; 
		stopped = true;
		
		attempt[level] = 0;
		//PlayerPrefs.SetInt("savedAttempt"+level, attempt[level]);
		//PlayerPrefs.Save();
		
		FloorInstructions.instance.Remove();
		yield return new WaitForSeconds(5);
		Reset();
		Application.LoadLevel (0); 

		//Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
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
		return levelDefinition.getLevels(controllers.Count)[level].getTimeToFirstMonster ()
			+ (dynamicDifficulty * (int)(Mathf.Min(attempt[level] / attemptsForChange, delayMax) * delay));
	}
	
	public int getTimeBetweenMonsters()
	{
		return levelDefinition.getLevels(controllers.Count)[level].getTimeBetweenMonsters ()
			+ (dynamicDifficulty * (int)(Mathf.Min(attempt[level] / attemptsForChange, delayMax) * delay));
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
	
	public void setStopped(bool stopped)
	{
		this.stopped = stopped;
	}
	
	public int getMaxLevel()
	{
		return maxLevel;
	}
	
	public void updateMaxLevel()
	{
		if (ENABLE_ALL_LEVELS)
		{
			//maxLevel = getNumberOfLevels ();
			maxLevel = totalLevels-1;
		}
	}

	public bool getEnableAllLevels()
	{
		return ENABLE_ALL_LEVELS;
	}
	
	public int getLevel()
	{
		return level;
		
	}
	
	public int getNumberOfLevels()
	{
		return  levelDefinition.getLevels (controllers.Count).Count - 1;
	}
	
	public int getTotalLevels()
	{
		return  totalLevels;
	}
	
	public void setLevel(int newLevel)
	{
		level = newLevel;
	}
	
	public List<InputController> getControllers()
	{
		return controllers;
	}
	
	public void setControllers(List<InputController> controllers)
	{
		this.controllers = controllers;
	}
	
	public bool isDecoyFixed()
	{
		return decoyFixed;
	}
	
	public void setDecoyFixed(bool decoyFixed)
	{
		this.decoyFixed = decoyFixed;
	}
	public void setDeadCount()
	{
		deadCount++;
		PlayerPrefs.SetInt("savedDeadCount", deadCount);
	}
	public int getDeadCount()
	{
		return deadCount;
	}
	public int getHomeVersion()
	{
		return homeVersion;
	}
	
}
