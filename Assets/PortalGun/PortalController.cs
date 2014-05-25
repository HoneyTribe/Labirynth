using UnityEngine;
using System.Collections.Generic;

public class PortalController : MonoBehaviour {

	private PortalController theOtherPortal;
	private bool settled;

	private List<GameObject> closeObjects = new List<GameObject> ();

	public void setTheOtherPortal(PortalController theOtherPortal)
	{
		this.theOtherPortal = theOtherPortal;
	}

	public bool isSettled()
	{
		return this.settled;
	}

	public bool hasCloseObjects()
	{
		return closeObjects.Count != 0;
	}

	void Update()
	{
		if ((theOtherPortal != null) &&
		    (isSettled()) && (theOtherPortal.isSettled()) &&
		    ((hasCloseObjects()) || (theOtherPortal.hasCloseObjects()))
		   )
		{
			foreach (GameObject obj in closeObjects)
			{
				if ((obj.tag == "Player") || (obj.tag == "Monster"))
				{
					Vector3 centralPosition = Instantiation.instance.getCentralPosition(theOtherPortal.transform.position);
					Vector3 pointBetween = Vector3.Lerp(centralPosition, theOtherPortal.transform.position, 0.5f);
					obj.transform.position = new Vector3(pointBetween.x, obj.transform.position.y, pointBetween.z);

					if (obj.tag == "Monster")
					{
						obj.gameObject.SendMessage("Recalculate");
					}
				}
			}
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider collider)
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

	void OnTriggerExit(Collider collider)
	{
		closeObjects.Remove (collider.gameObject);
	}
}

