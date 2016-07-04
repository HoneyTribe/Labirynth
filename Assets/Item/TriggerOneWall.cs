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

	private Texture greyTexture;
	private Material myMaterial;
	private Renderer rend;

	void Start()
	{
		smokeExplode = (GameObject) Resources.Load("SmokeExplode");
		cam = GameObject.Find ("MainCamera_Front");

		greyTexture = Resources.Load("/Alexis_Trigger/Materials/Trigger_Grey") as Texture;
		rend = GetComponent<Renderer>();
		myMaterial = rend.material;
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
			gameObject.transform.Translate (0, 0, -0.6f);
			myMaterial.SetTexture("_EmissionMap", greyTexture);
			myMaterial.SetColor ("_EmissionColor", Color.grey);
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
				GameObject[] players= GameObject.FindGameObjectsWithTag ("Player");
				foreach (GameObject player in players)
				{
					if (player.GetComponent<Collider>().isTrigger == false) // if not killed
					{
						player.GetComponent<Rigidbody>().useGravity = true;
						// stupid hack to wake up rigidbody :-((((
						player.GetComponent<Rigidbody>().AddForce(0, 1, 0, ForceMode.VelocityChange);
					}

				}
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
