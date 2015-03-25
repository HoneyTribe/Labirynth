using UnityEngine;
using System.Collections.Generic;

public class NewMazeEnding : MonoBehaviour {

	public static NewMazeEnding instance;

	private static float interval = 3.5f;

	private bool endingEnabled;
	private float time;
	private float earthquakeTimer;

	private List<GameObject> pillars = new List<GameObject>();
	private List<GameObject> walls = new List<GameObject>();

	private List<GameObject> risingWalls;
	
	void Start()
	{
		instance = this;

		foreach (GameObject pillar in GameObject.FindGameObjectsWithTag ("Pillar"))
		{
			pillars.Add(pillar);
		}
		
		foreach (GameObject wall in GameObject.FindGameObjectsWithTag ("Wall"))
		{
			walls.Add(wall);
		}
	}

	void Update()
	{
		if (endingEnabled)
		{
			if (time > interval) // it should happen after destroy
			{
				endingEnabled = false;
				time = 0;
				AstarPath.active.Scan();
				LevelFinishedController.instance.setStopped(false);
				print (endingEnabled);
				return;
			}

			float step = -Time.deltaTime * 2.5f / interval;
			time += Time.deltaTime;
			earthquakeTimer += Time.deltaTime;

			if (earthquakeTimer > 0.7f)
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


			 if (time > interval)
			 {

				foreach (GameObject pillar in GameObject.FindGameObjectsWithTag ("Pillar"))
				{
					pillars.Add(pillar);
				}
				
				foreach (GameObject wall in GameObject.FindGameObjectsWithTag ("Wall"))
				{
					walls.Add(wall);
				}
			}

		}
	}
	
	public void EnableNewMazeEnding()
	{
		risingWalls = Instantiation.instance.createNewWalls();
		this.endingEnabled = true;
		LevelFinishedController.instance.setStopped(true);
	}
}
