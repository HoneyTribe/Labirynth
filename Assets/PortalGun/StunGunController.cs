using UnityEngine;
using System.Collections;

public class StunGunController : MonoBehaviour {

	public void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Monster")
		{
			collider.gameObject.SendMessage("Paralyse");
			AudioController.instance.Play("020_DroneBombCollide");
		}
		else if (collider.name == "Ground" || collider.name == "SpaceMachine")
		{
			Destroy (gameObject);
		}
		
	}
}
