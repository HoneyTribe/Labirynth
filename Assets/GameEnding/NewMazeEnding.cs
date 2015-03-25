using UnityEngine;
using System.Collections.Generic;

public class NewMazeEnding : MonoBehaviour {

	public static NewMazeEnding instance;

	private static float interval = 3.5f;

	private bool endingEnabled;
	private float time;
	private float earthquakeTimer;

	private List<GameObject> pillars;
	private List<GameObject> walls;

	private List<GameObject> risingWalls;
	
	void Start()
	{
		instance = this;		
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
	
	public void EnableNewMazeEnding()
	{
		pillars = new List<GameObject>();
		foreach (GameObject pillar in GameObject.FindGameObjectsWithTag ("Pillar"))
		{
			pillars.Add(pillar);
		}

		walls = new List<GameObject> ();		
		foreach (GameObject wall in GameObject.FindGameObjectsWithTag ("Wall"))
		{
			walls.Add(wall);
		}

		risingWalls = Instantiation.instance.createNewWalls();
		this.endingEnabled = true;
		LevelFinishedController.instance.setStopped(true);
	}
}
