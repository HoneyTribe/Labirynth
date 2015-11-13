using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallSpawnSmoke : MonoBehaviour {

	private GameObject smokeExplode;
	private bool hasSpawned = false;
	private Vector3 smokeTempPos;
	private float smokeYOffset = 1.0f;

	// Use this for initialization
	void Start () 
	{
		smokeExplode = (GameObject) Resources.Load("SmokeExplode");
	}

	public bool getHasSpawned()
	{
		return hasSpawned;
	}

	public void changeHasSpawned()
	{
		hasSpawned = true;
	}

	public void spawn()
	{
		hasSpawned = true;
		smokeExplode = (GameObject) Instantiate(smokeExplode, transform.position, transform.rotation);
		smokeTempPos = transform.position;
		smokeTempPos.y += smokeYOffset;
		smokeExplode.transform.position = smokeTempPos;
		smokeExplode.transform.rotation = transform.rotation;
		
	}
	

}
