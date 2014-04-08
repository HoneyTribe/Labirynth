using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelFinishedController : MonoBehaviour {

	public static LevelFinishedController instance;
	public float gameSpeed = 1.0f;

	private int level = 0;
	private int maxLevel = 0;
	private AssemblyCSharp.LevelDefinition levelDefinition;

	public GameObject menuPrefab;

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
		Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
		maxLevel = getNumberOfLevels ();
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

	private void Reset()
	{
		finished = false;
		gameOver = false;
		congratulation = false;
		stopped = false;
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 200, 20, 300, 100), "Level: " + (level + 1)); 

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
		yield return new WaitForSeconds(2);
		gameOver = false;
		Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
	}

	IEnumerator GameFinished () 
	{
		congratulation = true; 
		stopped = true;
		yield return new WaitForSeconds(2);
		congratulation = false;
		Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
	}
	
	public int getNumberOfKeys()
	{
		return levelDefinition.getLevels()[level].getNumberOfKeys();
	}

	public List<AssemblyCSharp.MonsterTemplate> getMonsters()
	{
		return levelDefinition.getLevels()[level].getMonsters ();
	}

	public int getTimeToFirstMonster()
	{
		return levelDefinition.getLevels()[level].getTimeToFirstMonster ();
	}

	public int getTimeBetweenMonsters()
	{
		return levelDefinition.getLevels()[level].getTimeBetweenMonsters ();
	}

	public int getMazeSizeX()
	{
		return levelDefinition.getLevels()[level].getMazeSizeX ();
	}

	public int getMazeSizeZ()
	{
		return levelDefinition.getLevels()[level].getMazeSizeZ ();
	}

	public bool isStopped()
	{
		return stopped;
	}

	public int getMaxLevel()
	{
		return maxLevel;
	}

	public int getLevel()
	{
		return level;
	}

	public int getNumberOfLevels()
	{
		return  levelDefinition.getLevels ().Count - 1;
	}

	public void setLevel(int newLevel)
	{
		level = newLevel;
		Reset ();
	}
}
