using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	private PortalController theOtherPortal;
	private bool settled;

	public void setTheOtherPortal(PortalController theOtherPortal)
	{
		this.theOtherPortal = theOtherPortal;
	}

	public void setSettled()
	{
		this.settled = true;
	}

	public bool isSettled()
	{
		return this.settled;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "Ground")
		{
			settled = true;
		}
		else
		{
			if ((theOtherPortal != null) && (isSettled()) && (theOtherPortal.isSettled()))
			{
				if ((collider.tag == "Player") || (collider.tag == "Monster"))
				{
					Vector3 centralPosition = AssemblyCSharp.Instantiation.instance.getCentralPosition(theOtherPortal.transform.position);
					Vector3 pointBetween = Vector3.Lerp(centralPosition, theOtherPortal.transform.position, 0.5f);
					collider.transform.position = new Vector3(pointBetween.x, collider.transform.position.y, pointBetween.z);
					Destroy (theOtherPortal.gameObject);
					Destroy (gameObject.gameObject);

					if (collider.tag == "Monster")
					{
						collider.gameObject.SendMessage("Recalculate");
					}
				}
			}
		}
	}
}

