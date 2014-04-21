﻿using UnityEngine;
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
			heldObject.rigidbody.velocity = new Vector3(0, -10, 0);
			if ((heldObject.tag == "Player") || (heldObject.tag == "Monster"))
			{
				heldObject.gameObject.SendMessage("setStopped", false);
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
				GameObject obj = collider.gameObject;
				if (obj.transform.parent != null)
				{
					obj = obj.transform.parent.gameObject;
				}
				obj.rigidbody.useGravity = false;
				obj.transform.parent = transform;
				if ((obj.tag == "Player") || (obj.tag == "Monster"))
				{
					obj.gameObject.SendMessage("setStopped", true);
				}
				heldObject = obj;
			}
		}
	}
}