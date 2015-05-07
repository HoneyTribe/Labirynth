using UnityEngine;
using System.Collections;

public class LevelChangeController : MonoBehaviour {

	private static float interval = 0.1f;

	public int change;

	private TextMesh levelScreen;
	private float time = interval;

	void Start ()
	{
		levelScreen = GameObject.Find ("Level").GetComponent<TextMesh> ();
	}

	public void Change ()
	{
		time -= Time.deltaTime;
		if (time < 0)
		{
			UpdateLevel ();
			time = interval;
		}
	}

	private void UpdateLevel ()
	{
		int newLevel = LevelFinishedController.instance.getLevel () + change;
		if (newLevel >= 0 && newLevel <= LevelFinishedController.instance.getMaxLevel())
		{
			LevelFinishedController.instance.setLevel (newLevel);
			levelScreen.text = (newLevel + 1).ToString();
		}
	}
}
