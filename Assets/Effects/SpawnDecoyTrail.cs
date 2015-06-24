using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnDecoyTrail : MonoBehaviour 
{
	private GameObject trailObject;
	private bool hasSpawned = true;

	//void Start()
	//{
	//
	//}
	
	void Update()
	{
		if(transform.GetComponent<AbstractMonsterController>().getTimeLeft() > 0 )
		{
			if (hasSpawned == false)
			{
				spawn();
			}
		}

		print (hasSpawned);
	}

	private void spawn()
	{
			trailObject = (GameObject) Instantiate(trailObject, transform.position, transform.rotation);
			trailObject.transform.parent = gameObject.transform;
			trailObject.transform.localPosition = Vector3.zero;
			hasSpawned = true;
	}
	//triggered from DecoyTrailOnce and AbstractMonsterController
	public void changeHasSpawned()
	{
		trailObject = (GameObject) Resources.Load("TrailObject");
		hasSpawned = false;
	}
	
}
