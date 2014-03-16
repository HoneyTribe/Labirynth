using UnityEngine;
using System.Collections;

public class LevelFinishedController : MonoBehaviour {

	private int numberOfPlayers = 0;
	private bool finished;
	private bool gameOver;

	void OnGUI()
	{
		if (finished)
		{
			GUI.Label (new Rect (Screen.width / 2 - 200, 200, 300, 100), "LEVEL COMPLETE");
		}
		if (gameOver)
		{
			GUI.Label (new Rect (Screen.width / 2 - 200, 200, 300, 100), "GAME OVER");
		}
	}

	IEnumerator PlayerFinished () 
	{
		numberOfPlayers++;
		if (numberOfPlayers == 2) 
		{
			finished = true; 
			yield return new WaitForSeconds(1);
			Application.LoadLevel (0); 
		}
	}

	IEnumerator PlayerLost () 
	{
		gameOver = true; 
		yield return new WaitForSeconds(1);
		Application.LoadLevel (0); 
	}
}
