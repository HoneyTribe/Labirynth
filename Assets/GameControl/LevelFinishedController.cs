using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelFinishedController : MonoBehaviour {

	public static LevelFinishedController instance;
	public float gameSpeed = 1.0f;

	private int level = 0;
	private int maxLevel = 0;
	private AssemblyCSharp.LevelDefinition levelDefinition;

	public GameObject playerSelectionMenuPrefab;

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
		Instantiate (playerSelectionMenuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
	}

	private void LoadNewLevel()
	{
		level++;
		if (level > maxLevel)
		{
			maxLevel = level;
		}
		if (level > getNumberOfLevels ())
		{
			StartCoroutine(GameFinished());
		}
		else
		{
			Reset ();
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
			GUI.Label (new Rect (Screen.width / 2 - 200, 20, 300, 100), "Level: " + (level + 1)); 
		}

		if (finished)
		{
			GUI.Label (new Rect (Screen.width / 2 - 200, 200, 300, 100), "LEVEL COMPLETE");
		}
		if (gameOver)
		{
			GUI.Label (new Rect (Screen.width / 2 - 200, 200, 300, 100), "GAME OVER");
		}
		if (congratulation)
		{
			GUI.Label (new Rect (Screen.width / 2 - 200, 200, 300, 100), "CONGRATULATION! YOU FINISHED THE GAME!");
		}
	}

	IEnumerator PlayerFinished () 
	{
		finished = true; 
		stopped = true;
		yield return new WaitForSeconds(2);
		finished = false; 
		LoadNewLevel();
	}

	IEnumerator PlayerLost () 
	{
		gameOver = true; 
		stopped = true;
		GameObject.Find ("MainCamera_Front").SendMessage ("StartEarthquake");
		yield return new WaitForSeconds(2);
		gameOver = false;
		Instantiate (playerSelectionMenuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
	}

	IEnumerator GameFinished () 
	{
		congratulation = true; 
		stopped = true;
		yield return new WaitForSeconds(2);
		congratulation = false;
		Instantiate (playerSelectionMenuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
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
		maxLevel = getNumberOfLevels ();
	}

	public int getLevel()
	{
		return level;
	}

	public int getFirstLevelWithDevice()
	{
		return levelDefinition.getFirstLevelWithDevice();
	}

	public int getFirstLevelWithJumpItem()
	{
		return levelDefinition.getFirstLevelWithJumpItem();
	}

	public int getFirstLevelWithLightMachine()
	{
		return levelDefinition.getFirstLevelWithLightMachine();
	}
	
	public int getFirstLevelWithCrane()
	{
		return levelDefinition.getFirstLevelWithCrane();
	}

	public int getFirstLevelWithSmasher()
	{
		return levelDefinition.getFirstLevelWithSmasher();
	}

	public int getFirstLevelWithDrone()
	{
		return levelDefinition.getFirstLevelWithDrone();
	}

	public int getFirstLevelWithStunGun()
	{
		return levelDefinition.getFirstLevelWithStunGun();
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
