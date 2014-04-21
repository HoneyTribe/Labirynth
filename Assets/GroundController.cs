using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

	public void OnCollisionEnter(Collision collision)
	{
		OnTriggerEnter (collision.collider);
	}

	public void OnTriggerEnter(Collider collider)
	{
		collider.rigidbody.useGravity = false;
		collider.rigidbody.velocity = Vector3.zero;
	}
}
