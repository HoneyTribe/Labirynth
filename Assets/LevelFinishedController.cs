using UnityEngine;
using System.Collections;

public class LevelFinishedController : MonoBehaviour {

	private static bool created = false;

	private int level = 0;
	private int maxLevel = 0;
	private AssemblyCSharp.LevelDefinition levelDefinition;

	public GameObject menuPrefab;

	private int numberOfPlayers;
	private bool finished;
	private bool gameOver;
	private bool congratulation;
	private bool stopped;

	void Awake() {
		if (!created) {
			// this is the first instance - make it persist
			DontDestroyOnLoad(gameObject);
			created = true;
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
	}

	private void LoadNewLevel()
	{
		level++;
		if (level > maxLevel)
		{
			maxLevel = level;
		}
		if (level == levelDefinition.getLevels().Count)
		{
			GameFinished();
		}
		Reset ();
	}

	private void Reset()
	{
		finished = false;
		gameOver = false;
		congratulation = false;
		stopped = false;
		numberOfPlayers = 0;
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
		numberOfPlayers++;
		if (numberOfPlayers == 2) 
		{
			finished = true; 
			stopped = true;
			yield return new WaitForSeconds(1);
			LoadNewLevel();
			Application.LoadLevel (0); 
		}
	}

	IEnumerator PlayerLost () 
	{
		gameOver = true; 
		stopped = true;
		yield return new WaitForSeconds(1);
		Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
	}

	IEnumerator GameFinished () 
	{
		congratulation = true; 
		stopped = true;
		yield return new WaitForSeconds(1);
		Instantiate (menuPrefab, Vector3.zero, Quaternion.Euler (0, 0, 0));
	}
	
	public int getNumberOfKeys()
	{
		return levelDefinition.getLevels()[level].getNumberOfKeys();
	}

	public int getNumberOfMonsters()
	{
		return levelDefinition.getLevels()[level].getNumberOfMonsters ();
	}

	public bool isStopped()
	{
		return stopped;
	}

	public int getMaxLevel()
	{
		return maxLevel;
	}

	public int getNumberOfLevels()
	{
		return  levelDefinition.getLevels ().Count;
	}

	public void setLevel(int newLevel)
	{
		level = newLevel;
		Reset ();
	}
}
