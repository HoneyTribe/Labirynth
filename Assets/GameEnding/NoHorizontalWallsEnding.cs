using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoHorizontalWallsEnding : MonoBehaviour {
	
	public static NoHorizontalWallsEnding instance;
	
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
			// keep horizontal
			if (wall.transform.rotation.w == 1.0f)
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
			
			
			if (earthquakeTimer > 0.7f)
			{
				GameObject.Find ("MainCamera_Front").SendMessage ("StartEarthquake");
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
	
	public void EnableNoHorizontalWallsEnding()
	{
		this.endingEnabled = true;
	}
}
