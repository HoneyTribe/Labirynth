using UnityEngine;
using System.Collections.Generic;

public class TrapEnding : MonoBehaviour {

	private static float interval = 5;

	private bool endingEnabled;
	private float time;
	private float earthquakeTimer;

	private List<GameObject> pillars = new List<GameObject>();
	private List<GameObject> walls = new List<GameObject>();

	private List<GameObject> risingWalls;
	
	void Start()
	{
		foreach (GameObject pillar in GameObject.FindGameObjectsWithTag ("Pillar"))
		{
			if (Mathf.Abs(pillar.transform.position.z + Instantiation.planeSizeZ/2f - Instantiation.offsetZ) > 0.1)
			{
				pillars.Add(pillar);
			}
		}
		
		foreach (GameObject wall in GameObject.FindGameObjectsWithTag ("Wall"))
		{
			if (Mathf.Abs(wall.transform.position.z + Instantiation.planeSizeZ/2f - Instantiation.offsetZ) > 0.1)
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
				return;
			}

			float step = -Time.deltaTime * 2.5f / interval;
			time += Time.deltaTime;
			earthquakeTimer += Time.deltaTime;

			if (earthquakeTimer > 1)
			{
				GameObject.Find ("MainCamera_Front").SendMessage ("StartEarthquake");
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

			foreach (GameObject risingWall in risingWalls)
			{
				risingWall.transform.Translate (0, -step, 0);
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
	
	void EnableTrapEnding()
	{
		risingWalls = Instantiation.instance.createBlockingWalls();
		this.endingEnabled = true;
	}
}
