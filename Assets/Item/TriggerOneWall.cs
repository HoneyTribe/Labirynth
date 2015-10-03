using UnityEngine;
using System.Collections;

public class TriggerOneWall : MonoBehaviour
{
	private static float interval = 3.5f;

	private string reference;
	private bool endingEnabled = false;
	private float time;
	private GameObject wall;
	private float earthquakeTimer;
	private GameObject smokeExplode;
	private bool hasSpawned = false;
	private Vector3 smokeTempPos;
	private float smokeYOffset = 1.0f;
		private bool pushed = false;

	private GameObject cam;

	void Start()
	{
		smokeExplode = (GameObject) Resources.Load("SmokeExplode");
		cam = GameObject.Find ("MainCamera_Front");
	}

	public void setReference(string reference)
	{
		this.reference = reference;
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if (((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player")) && (!pushed))
		{
			pushed = true;
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.parent.transform.Translate (0, -0.5f, 0);
			wall = GameObject.Find("Textured Wall(Clone)" + reference);
			endingEnabled = true;
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

			if (hasSpawned == false)
			{
				spawn();
			}
			
			if (earthquakeTimer > 0.7f)
			{
				cam.SendMessage ("StartEarthquake");
				AudioController.instance.Play("033_Earthquake");
				earthquakeTimer = 0;
			}

			wall.transform.Translate (0, step, 0);

			if (time > interval)			
			{	
				Destroy(wall);
			}
		}
	}

	private void spawn()
	{
		hasSpawned = true;
		smokeExplode = (GameObject) Instantiate(smokeExplode, wall.transform.position, wall.transform.rotation);
		//smokeExplode.transform.parent = gameObject.transform;
		//smokeExplode.transform.position = wall.transform.position;
		smokeTempPos = wall.transform.position;
		smokeTempPos.y += smokeYOffset;
		smokeExplode.transform.position = smokeTempPos;
		smokeExplode.transform.rotation = wall.transform.rotation;

	}
}
