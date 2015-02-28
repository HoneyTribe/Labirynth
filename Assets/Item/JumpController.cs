using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpController : MonoBehaviour {

	public static JumpController instance;

	private List<GameObject> closeObjects = new List<GameObject>();

	private TextMesh textMesh;
	private bool taken;
	private int boxCollideCount = 0; // reset in PlayerController

	void Start()
	{
		instance = this;
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
				//textMesh.text = "TAKE ME!";
				if(LevelFinishedController.instance.getLevel() == 11)
				{
				boxCollideCount++;
				print ("boxCount: "+boxCollideCount);
				FloorInstructions.instance.ChangeInstructions();
				}


			}
			else
			{
				textMesh.text = "";
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

	public int GetBoxCollideCount()
	{
		return boxCollideCount;
	}

	//triggered in PlayerController
	public void resetBoxCollideCount()
	{
		boxCollideCount = -1;
	}

	//triggered in PlayerController
	public void addToBoxCollideCount()
	{
		boxCollideCount++;
	}
	
}
