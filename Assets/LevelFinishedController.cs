using UnityEngine;
using System.Collections;

public class LevelFinishedController : MonoBehaviour {

	private static bool created = false;

	private int level = 0;
	private AssemblyCSharp.LevelDefinition levelDefinition;

	private int numberOfPlayers = 0;
	private bool finished;
	private bool gameOver;
	private bool congratulation;

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
	}

	private void LoadNewLevel()
	{
		level++;
		if (level == levelDefinition.getLevels().Count)
		{
			GameFinished();
		}
		finished = false;
		gameOver = false;
		congratulation = false;
	}

	private void StartAgain()
	{
		level = 0;
		finished = false;
		gameOver = false;
		congratulation = false;
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
			yield return new WaitForSeconds(1);
			LoadNewLevel();
			Application.LoadLevel (0); 
		}
	}

	IEnumerator PlayerLost () 
	{
		gameOver = true; 
		yield return new WaitForSeconds(1);
		StartAgain();
		Application.LoadLevel (0); 
	}

	IEnumerator GameFinished () 
	{
		congratulation = true; 
		yield return new WaitForSeconds(1);
		StartAgain();
		Application.LoadLevel (0); 
	}
	
	public int getNumberOfKeys()
	{
		return levelDefinition.getLevels()[level].getNumberOfKeys();
	}

	public int getNumberOfMonsters()
	{
		return levelDefinition.getLevels()[level].getNumberOfMonsters ();
	}
}
