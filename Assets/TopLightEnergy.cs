using UnityEngine;
using System.Collections;

public class TopLightEnergy : MonoBehaviour {

	public static TopLightEnergy instance;

	// Use this for initialization
	void Start () 
	{
		instance = this;
		//Vector3 origPos = transform.position;
	}

	//Called from TopLightController
	public void ChangePos()
	{
		Vector3 lastPos = transform.position;

		if (TopLightController.instance.isEntered() == true)
		{
			transform.position = new Vector3(lastPos.x, -8.6f, lastPos.z+8); 
		}
		else
		{
			transform.position = new Vector3(lastPos.x, -30, lastPos.z-8);
		}
	}
}
