using UnityEngine;
using System.Collections;

public class StunGunController : MonoBehaviour {

	public void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Monster")
		{
			collider.gameObject.SendMessage("Paralyse");
		}
		else
		{
			if (collider.name != "Drone")
			{
				Destroy (gameObject);
			}
		}
	}
}
