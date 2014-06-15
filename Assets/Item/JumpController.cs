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
		if ((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player"))
		{
			if (!closeObjects.Contains(currentCollider.gameObject))
			{
				closeObjects.Add (currentCollider.gameObject);
			}

			taken = false;
			if (currentCollider.name.Contains("Player"))
			{
				textMesh.text = "TAKE ME!";
			}
			else
			{
				textMesh.text = "NOW!";
			}
		}
	}

	public void OnTriggerExit (Collider currentCollider)
	{
		if ((currentCollider.name.Contains("Monster")) || (currentCollider.name.Contains("Player")))
		{
			closeObjects.Remove (currentCollider.gameObject);
			if (closeObjects.Count == 0)
			{
				textMesh.text = "";
			}
		}
	}

	public void Activate()
	{
		if (!taken)
		{
			foreach (GameObject obj in closeObjects)
			{
				obj.SendMessage("Jump");
				AudioController.instance.Play("014_LightItem");
			}
		}
	}

	public bool hasAnyObjects()
	{
		return ((!taken) && (closeObjects.Count != 0));
	}
}
