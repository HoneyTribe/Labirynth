using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpController : MonoBehaviour {

	public static JumpController instance;

	private List<GameObject> closeObjects = new List<GameObject>();

	private bool taken;
	private int boxCollideCount = 0; // reset in PlayerController

	void Start()
	{
		instance = this;
	}

	public void Take()
	{
		taken = true;
	}

	public void Leave()
	{
		taken = false;
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player"))
		{
			if (!closeObjects.Contains(currentCollider.gameObject))
			{
				closeObjects.Add (currentCollider.gameObject);
			}

			//if (currentCollider.name.Contains("Player"))
			//{
				//if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstJumpBoxLevel)
				//{
				//boxCollideCount++;
				//FloorInstructions.instance.ChangeInstructions();
				//}


			//}
		}
	}

	public void OnTriggerExit (Collider currentCollider)
	{
		if ((currentCollider.name.Contains("Monster")) || (currentCollider.name.Contains("Player")))
		{
			closeObjects.Remove (currentCollider.gameObject);
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
