using UnityEngine;
using System.Collections;

public class CraneGrabberController : MonoBehaviour {

	private float grabberSpeed = 10f;

	private Vector3 grabberPosition;
	private Vector3 newGrabberPosition;
	public bool pickingUp;

	private GameObject heldObject;

	void Update()
	{
		if (pickingUp)
		{
			float distance = Vector3.Distance(transform.position, newGrabberPosition);
			
			if (distance != 0)
			{
				transform.position = Vector3.Lerp (
					transform.position, newGrabberPosition, Time.deltaTime * grabberSpeed / distance);
			}
			else
			{
				this.newGrabberPosition = this.grabberPosition;
				if (transform.position.Equals(this.grabberPosition))
				{
					pickingUp = false;
				}
			}
		}
	}

	public void PickUp() 
	{
		if (heldObject == null)
		{
			this.newGrabberPosition = new Vector3 (transform.position.x, 
			                                       transform.position.y - 7,
			                                       transform.position.z);
			this.grabberPosition = transform.position;
			this.pickingUp = true;
		}
		else
		{
			heldObject.rigidbody.useGravity = true;
			heldObject.transform.parent = null;
			if ((heldObject.tag == "Player") || (heldObject.tag == "Monster"))
			{
				heldObject.rigidbody.velocity = new Vector3(0, -10, 0);
				heldObject.gameObject.SendMessage("setStopped", false);
			}
			else
			{
				heldObject.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			}
			heldObject = null;
		}
	}
	
	void OnTriggerEnter (Collider collider)
	{
		this.newGrabberPosition = this.grabberPosition;
		if ((collider.tag == "Monster") || (collider.tag == "Item") || (collider.tag == "Player"))
		{
			if ((heldObject == null) && (pickingUp))
			{
				collider.rigidbody.useGravity = false;
				collider.transform.parent = transform;
				if ((collider.tag == "Player") || (collider.tag == "Monster"))
				{
					collider.gameObject.SendMessage("setStopped", true);
				}
				heldObject = collider.gameObject;
			}
		}
	}
}
