using UnityEngine;
using System.Collections;

public class LevelChangeController : MonoBehaviour {

	private static float interval = 0.1f;
	private static float deflection = 20f;

	public int change;

	private TextMesh levelScreen;
	private GameObject stick;
	private float time = interval;
	private float deflectionTime;
	private int audioCount = 0;

	void Start ()
	{
		levelScreen = GameObject.Find ("Level").GetComponent<TextMesh> ();
		stick = GameObject.Find ("StickAndBall");
		deflectionTime = Time.time;
	}

	public void Change ()
	{
		time -= Time.deltaTime;
		if ((stick.transform.rotation.z == 0) && 
		    (LevelFinishedController.instance.getLevel() > 0 && LevelFinishedController.instance.getLevel() < LevelFinishedController.instance.getMaxLevel()))
		{
			deflectionTime = Time.time;
			stick.transform.rotation =  Quaternion.Euler(0, 0, -change * deflection);
				if (time < 0)
				{
				AudioController.instance.Play("035_Select");
				}
		}
		if (time < 0)
		{
			UpdateLevel ();
			time = interval;
		}
	}

	void Update()
	{
		if ((Time.time - deflectionTime > 2 * interval) && (stick.transform.rotation.z != 0))
		{
			stick.transform.rotation =  Quaternion.Euler(0, 0, 0);
		}
	}

	private void UpdateLevel ()
	{
		int newLevel = LevelFinishedController.instance.getLevel () + change;
		if (newLevel >= 0 && newLevel <= LevelFinishedController.instance.getMaxLevel())
		{
			LevelFinishedController.instance.setLevel (newLevel);
			levelScreen.text = "Zone " + (newLevel + 1) + "/35";
		}
	}
}
