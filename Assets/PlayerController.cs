using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	private float speed = 8;	

	private bool lighthouseEntered = false;

	private bool gameFinished = false;

	private GameObject topLight;
	private GameObject levelController;
	private GameObject device;
	private LevelFinishedController levelFinishedController;

	private AssemblyCSharp.Inventory inventory = new AssemblyCSharp.Inventory();

	private bool playerActive;

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
		if (action2 > 0)
		{
			if (lighthouseEntered)
			{
				lighthouseEntered = false;
				topLight.gameObject.SendMessage("TurnOff");
				rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
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
			else
			{
				device.gameObject.SendMessage("Move", transform.localPosition);
			}
		}

		if (!lighthouseEntered)
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

	public void JumpItemAvailable(GameObject item)
	{
		inventory.setAvailableItem (item);
	}

	public void JumpItemNotAvailable()
	{
		inventory.setAvailableItem (null);
	}

	void OnCollisionEnter (Collision collision)
	{
		if(collision.collider.name == "Lighthouse")
		{
			lighthouseEntered = true;
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			topLight.gameObject.SendMessage("TurnOn");
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
		}
	}
}
