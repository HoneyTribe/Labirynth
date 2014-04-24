using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour, StoppableObject {

	private float speed = 10;	

	private bool lighthouseEntered = false;
	private bool craneEntered = false;
	private bool portalGunEntered = false;

	private bool gameFinished = false;

	private GameObject topLight;
	private GameObject levelController;
	private LevelFinishedController levelFinishedController;

	private AssemblyCSharp.Inventory inventory = new AssemblyCSharp.Inventory();

	private bool playerActive;
	private bool inputBlocked;

	void Start()
	{
		speed *= LevelFinishedController.instance.gameSpeed;
		topLight = GameObject.Find ("TopLight");
		levelController = GameObject.Find ("LevelController");
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController>();
	}

	public void handleLogic(float x, float z, float action, float action2)
	{
		if ((inputBlocked) || (levelFinishedController.isStopped()))
		{
			return;
		}

		if (lighthouseEntered)
		{
			if ((action > 0.5) || (action2 > 0.5))
			{
				lighthouseEntered = false;
				topLight.gameObject.SendMessage("TurnOff");
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				rigidbody.transform.Translate(new Vector3(0,0,-1.0f));
			}

			if ((action > 0) && (action <= 0.5f))
			{
				topLight.gameObject.SendMessage("AttractMonster");
			}

			
			if ((action2 > 0) && (action2 <= 0.5f))
			{
				topLight.gameObject.SendMessage("ActivateItems");
			}

			if(x < 0)
			{
				LightController.instance.gameObject.SendMessage("MoveLeft");
			}
			
			if(x > 0)
			{
				LightController.instance.gameObject.SendMessage("MoveRight");
			}
		}
		else if (craneEntered)
		{
			if ((action > 0.5) || (action2 > 0.5))
			{
				craneEntered = false;
				CraneController.instance.TurnOff();
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				rigidbody.transform.Translate(new Vector3(0,0,-1.0f));
			}

			if ((action > 0) && (action <= 0.5f))
			{
				CraneController.instance.PickUp();
			}

			if ((action2 > 0) && (action2 <= 0.5f))
			{
				CraneController.instance.Activate();
			}

			if ((x != 0) || (z != 0))
			{
				CraneController.instance.Move(new Vector3(x,action,z));
			}
		}
		else if (portalGunEntered)
		{
			if ((action > 0.5) || (action2 > 0.5))
			{
				portalGunEntered = false;
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				rigidbody.transform.Translate(new Vector3(0,0,-1.0f));
			}
			
			if ((x != 0) || (z != 0))
			{
				PortalGunController.instance.Move(new Vector3(x,action,z));
			}

			if ((action > 0) && (action <= 0.5f))
			{
				PortalGunController.instance.Shoot();
			}
		}
		else
		{
			if (action > 0)
			{
				DeviceController.instance.Move(transform.position);
			}

			if (action2 > 0)
			{
				if (inventory.getInventoryItem() == null)
				{
					GameObject jumpItem = inventory.getAvailablItem();
					if (jumpItem != null)
					{
						jumpItem.transform.localPosition = new Vector3(transform.localPosition.x,
						                                               transform.localPosition.y + 4,
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
					inventory.setAvailableItem(inventory.getInventoryItem());
					inventory.clearInventory();
				}
			}

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

	public bool hasEnteredAnyMachine()
	{
		return lighthouseEntered || craneEntered || portalGunEntered;
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
		if(collision.collider.name == "PortalGun")
		{
			portalGunEntered = true;
			freeze();
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
