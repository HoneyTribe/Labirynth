using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour, StoppableObject {

	private static int closeDistance = 3;
	private float speed = 10;	

	private bool lighthouseEntered = false;
	private bool craneEntered = false;
	private bool portalGunEntered = false;

	private GameObject gameController;

	private AssemblyCSharp.Inventory inventory = new AssemblyCSharp.Inventory();

	private bool playerActive;
	private bool inputBlocked;
	private bool paralysed;
	private Color originalColor;
	private bool puzzleSound = false;

	private List<GameObject> players = new List<GameObject>();

	void Start()
	{
		speed *= LevelFinishedController.instance.gameSpeed;
		gameController = GameObject.Find ("GameController");
		originalColor = transform.GetChild(0).transform.GetChild(0).gameObject.renderer.materials[0].color;

		for (int i=1; i<=LevelFinishedController.instance.getControllers().Count; i++)
		{
			if (!gameObject.name.Contains(i.ToString()))
			{
				players.Add(GameObject.Find ("Player" + i));
			}
		}
	}

	public void handleLogic(float x, float z, float action, float action2)
	{
		if ((inputBlocked) || (paralysed) || (LevelFinishedController.instance.isStopped()))
		{
			return;
		}

		if (lighthouseEntered)
		{
			if ((action > InputController.BUTTON_DURATION) || (action2 > InputController.BUTTON_DURATION))
			{
				lighthouseEntered = false;
				AudioController.instance.Play("012_LightOffB");
				TopLightController.instance.TurnOff();
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				rigidbody.transform.Translate(new Vector3(0,0,-1.0f));
			}

			if ((action > 0) && (action <= InputController.BUTTON_DURATION))
			{
				TopLightController.instance.AttractMonster();
				AudioController.instance.Play("013_LightZap");
			}

			
			if ((action2 > 0) && (action2 <= InputController.BUTTON_DURATION))
			{
				TopLightController.instance.ActivateItems();
				AudioController.instance.Play("014_LightItem");
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
			if ((action > InputController.BUTTON_DURATION) || (action2 > InputController.BUTTON_DURATION))
			{
				craneEntered = false;
				CraneController.instance.TurnOff();
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				rigidbody.transform.Translate(new Vector3(0,0,-1.0f));
			}

			if ((action > 0) && (action <= InputController.BUTTON_DURATION))
			{
				CraneController.instance.PickUp();
				AudioController.instance.Play("015_craneGrabs");
			}

			if ((action2 > 0) && (action2 <= InputController.BUTTON_DURATION))
			{
				CraneController.instance.SmashWall();
				AudioController.instance.Play("017_CraneLazer");
			}

			if ((x != 0) || (z != 0))
			{
				CraneController.instance.Move(new Vector3(x,action,z));
			}
		}
		else if (portalGunEntered)
		{
			if ((action > InputController.BUTTON_DURATION) || (action2 > InputController.BUTTON_DURATION))
			{
				portalGunEntered = false;
				DroneController.instance.TurnOff();
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				rigidbody.transform.Translate(new Vector3(0,0,-1.0f));
			}
			
			DroneController.instance.Move(new Vector3(x,action,z));

			if ((action > 0) && (action <= InputController.BUTTON_DURATION))
			{
				DroneController.instance.Shoot();
			}

			if ((action2 > 0) && (action2 <= InputController.BUTTON_DURATION))
			{
				DroneController.instance.UseStunGun();
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
						AudioController.instance.Play("005_PickUp");
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
					AudioController.instance.Play("006_Drop");
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

	void Update()
	{
		if (paralysed)
		{
			foreach (GameObject player in players)
			{
				if (Vector3.Distance(transform.localPosition, player.transform.localPosition) < closeDistance)
				{
					gameController.SendMessage("PlayerReviwed");
					transform.GetChild(0).transform.GetChild(0).gameObject.renderer.materials[0].color = originalColor;
					collider.isTrigger = false;
					paralysed = false;
					break;
				}
			}
		}
	}

	public bool hasEnteredAnyMachine()
	{
		return lighthouseEntered || craneEntered || portalGunEntered;

	}

	public bool isParalysed()
	{
		return this.paralysed;
	}

	public void setStopped(bool inputBlocked)
	{
		this.inputBlocked = inputBlocked;
	}

	void OnCollisionEnter (Collision collision)
	{
		if(collision.collider.name == "Lighthouse")
		{
			if (!TopLightController.instance.isEntered())
			{
				lighthouseEntered = true;
				freeze();
				TopLightController.instance.TurnOn();
				AudioController.instance.Play("011_LightOn");
			}
		}
		if(collision.collider.name == "Crane")
		{
			if (!CraneController.instance.isEntered())
			{
				craneEntered = true;
				freeze();
				CraneController.instance.TurnOn();
			}
		}
		if(collision.collider.name == "PortalGun")
		{
			if (!DroneController.instance.isEntered())
			{
				portalGunEntered = true;
				freeze();
				DroneController.instance.TurnOn();
			}
		}
		if((collision.collider.name == "Monster(Clone)") ||
 		   (collision.collider.name == "FlyingMonster(Clone)"))
		{
			if (!paralysed)
			{
				paralysed = true;
				gameController.SendMessage("PlayerParalysed");
				AudioController.instance.Play("008_dead");
				transform.GetChild(0).transform.GetChild(0).gameObject.renderer.materials[0].color=Color.grey;
				collider.isTrigger = true;
				collision.collider.rigidbody.velocity = Vector3.zero;
				collision.collider.rigidbody.angularVelocity = Vector3.zero;
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
				//collision.gameObject.SendMessage("Recalculate");
			}
		}
	}

	void OnCollisionStay (Collision collision)
	{
		if(collision.collider.name == "Block")
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			collision.gameObject.SendMessage("Move", -collision.contacts[0].normal);
			if(puzzleSound == false)
				{
				AudioController.instance.Play("021_BlockMovesB");
				}
			puzzleSound = true;
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
