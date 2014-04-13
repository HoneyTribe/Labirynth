using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpController : MonoBehaviour {

	private List<GameObject> closeObjects = new List<GameObject>();

	private TextMesh textMesh;
	private bool taken;

	void Start()
	{
		textMesh = gameObject.GetComponentInChildren<TextMesh> ();
	}

	public void Take()
	{
		taken = true;
		textMesh.text = "";
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if (!closeObjects.Contains(currentCollider.gameObject))
		{
			closeObjects.Add (currentCollider.gameObject);
		}
		if (currentCollider.name != "Monster")
		{
			taken = false;
			textMesh.text = "TAKE ME!";
			currentCollider.gameObject.SendMessage("JumpItemAvailable", gameObject);
		}
	}

	public void OnTriggerExit (Collider currentCollider)
	{
		closeObjects.Remove (currentCollider.gameObject);
		if (currentCollider.name != "Monster")
		{
			textMesh.text = "";
			currentCollider.gameObject.SendMessage("JumpItemNotAvailable", gameObject);
		}
	}

	public void Activate()
	{
		if (!taken)
		{
			foreach (GameObject obj in closeObjects)
			{
				obj.rigidbody.AddRelativeForce(Vector3.up * 500 + Vector3.forward * 120);
			}
		}
	}

	public bool hasAnyObjects()
	{
		return ((!taken) && (closeObjects.Count != 0));
	}
}
