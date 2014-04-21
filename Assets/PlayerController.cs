using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour, StoppableObject {

	private float speed = 10;	

	private bool lighthouseEntered = false;
	private bool craneEntered = false;

	private bool gameFinished = false;

	private GameObject topLight;
	private GameObject levelController;
	private GameObject device;
	private LevelFinishedController levelFinishedController;

	private AssemblyCSharp.Inventory inventory = new AssemblyCSharp.Inventory();

	private bool playerActive;
	private bool inputBlocked;

	void Start()
	{
		speed *= LevelFinishedController.instance.gameSpeed;
		topLight = GameObject.Find ("TopLight");
		levelController = GameObject.Find ("LevelController");
		device = GameObject.Find ("Device");
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController>();
	}

	public void handleLogic(float x, float z, float action, float action2)
	{
		if ((inputBlocked) || (levelFinishedController.isStopped()))
		{
			return;
		}

		if (action2 > 0)
		{
			if (lighthouseEntered)
			{
				lighthouseEntered = false;
				topLight.gameObject.SendMessage("TurnOff");
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				rigidbody.transform.Translate(new Vector3(0,0,-1.0f));
			}
			else if (craneEntered)
			{
				craneEntered = false;
				CraneController.instance.TurnOff();
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				rigidbody.transform.Translate(new Vector3(0,0,-1.0f));
			}
			else
			{
				if (inventory.getInventoryItem() == null)
				{
					GameObject jumpItem = inventory.getAvailablItem();
					if (jumpItem != null)
					{
						jumpItem.transform.localPosition = new Vector3(transform.localPosition.x,
						                                               transform.localPosition.y + 3,
						                                               transform.localPosition.z);
						jumpItem.transform.parent = gameObject.transform;
						jumpItem.rigidbody.isKinematic = true;
						jumpItem.SendMessage("Take");
						inventory.putItemIntoInventory();
					}
				}
				else
				{
					inventory.getInventoryItem().transform.position = new Vector3(transform.localPosition.x,
					                                            					   1.5f,
					                                               					   transform.localPosition.z);
					inventory.getInventoryItem().transform.rotation = Quaternion.Euler(0,0,0);
					inventory.getInventoryItem().transform.parent = null;
					inventory.getInventoryItem().rigidbody.isKinematic = false;
					inventory.getInventoryItem().SendMessage("OnTriggerEnter", collider);
					inventory.clearInventory();
				}
			}
		}

		if(x < 0)
		{
			if (lighthouseEntered)
			{
				LightController.instance.gameObject.SendMessage("MoveLeft");
			}
		}

		if(x > 0)
		{
			if (lighthouseEntered)
			{
				LightController.instance.gameObject.SendMessage("MoveRight");
			}
		}

		if(craneEntered)
		{
			if ((x != 0) || (z != 0))
			{
				CraneController.instance.Move(new Vector3(x,action,z));
			}
			
			if (action > 0)
			{
				CraneController.instance.PickUp();
			}
		}

		if (action > 0)
		{
			if (lighthouseEntered)
			{
				if (action > 0.5f)
				{
					topLight.gameObject.SendMessage("ActivateItems");
				}
				else
				{
					topLight.gameObject.SendMessage("AttractMonster");
				}
			}
		}

		if ((!lighthouseEntered) && (!craneEntered))
		{
			if ((x != 0) || (z != 0))
			{
				playerActive = true;
				rigidbody.velocity = new Vector3(x, 0, z).normalized * speed;
				transform.rotation = Quaternion.LookRotation(new Vector3(x, 0, z)); 
			}
			else
			{
				if (playerActive)
				{
					playerActive = false;
					rigidbody.velocity = new Vector3(x, 0, z).normalized * speed;
				}
			}
		}
	}

	public bool hasEnteredLighthouse()
	{
		return lighthouseEntered;
	}


	public void setStopped(bool inputBlocked)
	{
		this.inputBlocked = inputBlocked;
	}

	void OnCollisionEnter (Collision collision)
	{
		if(collision.collider.name == "Lighthouse")
		{
			lighthouseEntered = true;
			freeze();
			topLight.gameObject.SendMessage("TurnOn");
		}
		if(collision.collider.name == "Crane")
		{
			craneEntered = true;
			freeze();
			CraneController.instance.TurnOn();
		}
		if(collision.collider.name == "ExitTrigger")
		{
			if (!gameFinished)
			{
				gameFinished = true;
				gameObject.transform.Translate(gameObject.transform.localPosition.x * 10, 0, 0);
				levelController.gameObject.SendMessage("PlayerFinished");
			}
		}
		if((collision.collider.name == "Monster(Clone)") ||
 		   (collision.collider.name == "FlyingMonster(Clone)"))
		{
			if (!gameFinished)
			{
				gameFinished = true;
				levelController.gameObject.SendMessage("PlayerLost");
			}
			freeze();
		}
		if(collision.collider.name.Contains("Player"))
		{
			rigidbody.velocity = Vector3.zero;
		}
	}

	void OnCollisionExit (Collision collision)
	{
		if(collision.collider.name.Contains("Player"))
		{
			rigidbody.velocity = Vector3.zero;
		}
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if (currentCollider.tag == "Item")
		{
			inventory.setAvailableItem(currentCollider.gameObject);
		}
	}

	public void OnTriggerExit(Collider currentCollider)
	{
		if (currentCollider.tag == "Item")
		{
			inventory.setAvailableItem(null);
		}
	}

	private void freeze()
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}
}
