using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

	public void OnCollisionEnter(Collision collision)
	{
		OnTriggerEnter (collision.collider);
	}

	public void OnTriggerEnter(Collider collider)
	{
		collider.GetComponent<Rigidbody>().useGravity = false;
		collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
		if ((collider.tag == "Player") || (collider.tag == "Monster"))
		{
			collider.gameObject.SendMessage("setStopped", false);
		}

		if (collider.tag == "Item")
		{
			// check cranegrabberController
			collider.isTrigger = true;
			Physics.IgnoreLayerCollision(LayerMask.NameToLayer("players"), LayerMask.NameToLayer("item"), false);
			Physics.IgnoreLayerCollision(LayerMask.NameToLayer("monsters"), LayerMask.NameToLayer("item"), false);
			Physics.IgnoreLayerCollision(LayerMask.NameToLayer("flyingMonsters"), LayerMask.NameToLayer("item"), false);

		}
	}
}
