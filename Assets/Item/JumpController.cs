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

		taken = false;
		textMesh.text = "TAKE ME!";
	}

	public void OnTriggerExit (Collider currentCollider)
	{
		closeObjects.Remove (currentCollider.gameObject);
		if (closeObjects.Count == 0)
		{
			textMesh.text = "";
		}
	}

	public void Activate()
	{
		if (!taken)
		{
			foreach (GameObject obj in closeObjects)
			{
				obj.SendMessage("Jump");
			}
		}
	}

	public bool hasAnyObjects()
	{
		return ((!taken) && (closeObjects.Count != 0));
	}
}
