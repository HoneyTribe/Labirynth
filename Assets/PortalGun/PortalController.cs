using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	private GameObject theOtherPortal;

	public void setTheOtherPortal(GameObject theOtherPortal)
	{
		this.theOtherPortal = theOtherPortal;
	}

}

