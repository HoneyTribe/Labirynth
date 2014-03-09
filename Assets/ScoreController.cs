using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public static int numberOfKeys = 4;
	private int score = 0;

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 200, 20, 300, 100), "Keys: " + score); 
	}

	public void Score()
	{
		score++;
		if (score == numberOfKeys)
		{
			RenderSettings.ambientLight =  new Color(0.2F, 0.2F, 0.2F, 1.0F);
		}
	}

	public void foundAllKeys(ReturnValue returnValue)
	{
		if (score == numberOfKeys)
		{
			returnValue.value = true;
		}
	}
}
