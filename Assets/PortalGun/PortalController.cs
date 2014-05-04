using UnityEngine;
using System.Collections.Generic;

public class PortalController : MonoBehaviour {

	private static float speed = 10f;
	private static float height = 5f;
	private static float timeUp = height/speed;

	private PortalController theOtherPortal;
	private bool settled;
	private int state;
	private float time;

	private List<GameObject> closeObjects = new List<GameObject> ();

	public void setTheOtherPortal(PortalController theOtherPortal)
	{
		this.theOtherPortal = theOtherPortal;
	}

	public bool hasCloseObjects()
	{
		return closeObjects.Count != 0;
	}

	public bool isSettled()
	{
		return this.settled;
	}

	void Update()
	{
		if ((state == 0) && 
		    (theOtherPortal != null) && 
		    (isSettled()) && (theOtherPortal.isSettled()) &&
		    ((hasCloseObjects()) || (theOtherPortal.hasCloseObjects()))
		   )
		{
			state++;
			time = 0f;
			foreach (GameObject obj in closeObjects)
			{
				obj.rigidbody.useGravity = false;
				obj.rigidbody.velocity = new Vector3 (0, speed, 0);
				if ((obj.tag == "Player") || (obj.tag == "Monster"))
				{
					obj.gameObject.SendMessage("setStopped", true);
				}
			}
		}

		if (state == 1)
		{
			time += Time.deltaTime;

			if (time > timeUp)
			{
				foreach (GameObject obj in closeObjects)
				{
					if ((obj.tag == "Player") || (obj.tag == "Monster"))
					{
						Vector3 move = theOtherPortal.transform.position - transform.position;
						obj.transform.position = new Vector3(obj.transform.position.x + move.x,
						                                     height,
						                                     obj.transform.position.z + move.z);
						obj.rigidbody.useGravity = true;
						obj.rigidbody.velocity = new Vector3(0, -speed, 0);

						if (obj.tag == "Monster")
						{
							obj.gameObject.SendMessage("Recalculate");
						}
					}
				}
				Destroy (gameObject.gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (state == 0)
		{
			if (collider.name == "Ground")
			{
				settled = true;
			}

			if ((collider.tag == "Monster") || (collider.tag == "Item") || (collider.tag == "Player"))
			{
				if (!closeObjects.Contains(collider.gameObject))
				{
					closeObjects.Add (collider.gameObject);
				}
			}
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (state == 0)
		{
			closeObjects.Remove (collider.gameObject);
		}
	}
}

