using UnityEngine;
using System.Collections;

public class NoWallsEnding : MonoBehaviour {

	private static float interval = 3.5f;

	private bool endingEnabled;
	private float time;
	private float earthquakeTimer;

	private GameObject[] pillars;
	private GameObject[] walls;

	private GameObject cam;

	void Start()
	{
		pillars = GameObject.FindGameObjectsWithTag ("Pillar");
		walls = GameObject.FindGameObjectsWithTag ("Wall");
		cam = GameObject.Find ("MainCamera_Front");
	}

	void Update()
	{
		if (endingEnabled)
		{
			if (time > interval) // it should happen after destroy
			{
				endingEnabled = false;
				AstarPath.active.Scan();
			}

			float step = -Time.deltaTime * 2.5f / interval;
			time += Time.deltaTime;
			earthquakeTimer += Time.deltaTime;

			if (earthquakeTimer > 0.7f && LevelEnd.instance.IsStartSequence()==false)
			{
				cam.SendMessage ("StartEarthquake");
				AudioController.instance.Play("033_Earthquake");
				earthquakeTimer = 0;
			}

			foreach (GameObject wall in walls)
			{
				wall.transform.Translate (0, step, 0);
			}

			foreach (GameObject pillar in pillars)
			{
				pillar.transform.Translate (0, step, 0);
			}

			if (time > interval)			{

				foreach (GameObject wall in walls)
				{
					Destroy(wall);
				}
				
				foreach (GameObject pillar in pillars)
				{
					Destroy(pillar);
				}
			}
		}
	}
	
	void EnableNoWallsEnding()
	{
		this.endingEnabled = true;
	}
}
