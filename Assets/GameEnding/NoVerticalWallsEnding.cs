using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoVerticalWallsEnding : MonoBehaviour {

	public static NoVerticalWallsEnding instance;

	private static float interval = 3.5f;

	private bool endingEnabled;
	private float time;
	private float earthquakeTimer;

	private List<GameObject> walls = new List<GameObject>();

	void Start()
	{
		instance = this;

		GameObject[] w = GameObject.FindGameObjectsWithTag ("Wall");
		foreach (GameObject wall in w)
		{
			// keep vertical
			if (wall.transform.rotation.w != 1.0f)
			{
				walls.Add(wall);
			}
		}
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
				GameObject.Find ("MainCamera_Front").SendMessage ("StartEarthquake");
				AudioController.instance.Play("033_Earthquake");
				earthquakeTimer = 0;
			}

			foreach (GameObject wall in walls)
			{
				if (wall != null)
				{
					wall.transform.Translate (0, step, 0);
				}
			}

			if (time > interval)			{

				foreach (GameObject wall in walls)
				{
					Destroy(wall);
				}
			}
		}
	}
	
	public void EnableNoVerticalWallsEnding()
	{
		this.endingEnabled = true;
	}
}
