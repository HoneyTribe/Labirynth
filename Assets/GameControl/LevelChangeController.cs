using UnityEngine;
using System.Collections;

public class LevelChangeController : MonoBehaviour {

	private static float interval = 0.15f;
	private static float deflection = 20f;

	public int change;

	private TextMesh levelScreen;
	private GameObject stickL;
	private GameObject stickR;
	private float time = interval;
	private float deflectionTime;
	private int audioCount = 0;

	void Start ()
	{
		levelScreen = GameObject.Find ("Level").GetComponent<TextMesh> ();
		stickL = GameObject.Find ("Joypad_StickL");
		stickR = GameObject.Find ("Joypad_StickR");
		deflectionTime = Time.time;
	}

	public void Change ()
	{
		if(change > 0) //left side touched
		{
			time -= Time.deltaTime;
			if ((stickR.transform.rotation.z == 0) && 
			    (LevelFinishedController.instance.getLevel() >= 0 &&
			 	LevelFinishedController.instance.getLevel() < LevelFinishedController.instance.getMaxLevel()) )
			{
				deflectionTime = Time.time;
				stickR.transform.rotation =  Quaternion.Euler(0, 0, -change * deflection);
				if (time < 0)
				{
					AudioController.instance.Play("035_Select");
				}
			}
		}
		else //right side touched
		{
			time -= Time.deltaTime;
			if ((stickL.transform.rotation.z == 0) && 
			    (LevelFinishedController.instance.getLevel() > 0 &&
			 	LevelFinishedController.instance.getLevel() <= LevelFinishedController.instance.getMaxLevel()))
			{
				deflectionTime = Time.time;
				stickL.transform.rotation =  Quaternion.Euler(0, 0, -change * deflection);
				if (time < 0)
				{
					AudioController.instance.Play("035_Select");

				}
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
		if ((Time.time - deflectionTime > 2 * interval) && (stickL.transform.rotation.z != 0))
		{
			stickL.transform.rotation =  Quaternion.Euler(0, 0, 0);
		}

		if ((Time.time - deflectionTime > 2 * interval) && (stickR.transform.rotation.z != 0))
		{
			stickR.transform.rotation =  Quaternion.Euler(0, 0, 0);
		}
	}

	private void UpdateLevel ()
	{
		int newLevel = LevelFinishedController.instance.getLevel () + change;
		if (newLevel >= 0 && newLevel <= LevelFinishedController.instance.getMaxLevel())
		{
			LevelFinishedController.instance.setLevel (newLevel);
			levelScreen.text = "Zone " + (newLevel + 1) + "/" + LevelFinishedController.instance.getTotalLevels();
		}
	}
}
