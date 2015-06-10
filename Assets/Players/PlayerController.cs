using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour, StoppableObject {

	private static int closeDistance = 3;
	private static float timeBetweenRevivals = 2f;
	private float speed = 10;	

	private bool lighthouseEntered = false;
	private bool craneEntered = false;
	private bool portalGunEntered = false;
	private LevelChangeController levelChangeEntered = null;

	private GameObject gameController;

	private AssemblyCSharp.Inventory inventory = new AssemblyCSharp.Inventory();

	private bool playerActive;
	private bool inputBlocked;
	private bool paralysed;
	private Color originalColor;
	private float timeFromLastRevive = 0;

	private List<GameObject> players = new List<GameObject>();

	void Start()
	{
		speed *= LevelFinishedController.instance.gameSpeed;
		gameController = GameObject.Find ("GameController");
		originalColor = transform.GetChild(0).transform.GetChild(0).gameObject.renderer.materials[0].color;

		foreach (InputController inputController in LevelFinishedController.instance.getControllers())
		{
			if (!gameObject.name.Contains(inputController.getPlayerId().ToString()))
			{
				players.Add(GameObject.Find ("Player" + inputController.getPlayerId()));
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
			}

			
			if ((action2 > 0) && (action2 <= InputController.BUTTON_DURATION))
			{
				TopLightController.instance.ActivateItems();
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
				AudioController.instance.Play("012_LightOffB");
			}

			if ((action > 0) && (action <= InputController.BUTTON_DURATION))
			{
				CraneController.instance.PickUp();
			}

			if ((action2 > 0) && (action2 <= InputController.BUTTON_DURATION))
			{
				CraneController.instance.SmashWall();
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
				AudioController.instance.Play("012_LightOffB");
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
		else if (levelChangeEntered != null)
		{
			if (x * levelChangeEntered.change > 0)
			{
				levelChangeEntered.Change();
			}
			else
			{
				if (x * levelChangeEntered.change < 0 || z != 0)
				{
					levelChangeEntered = null;
				}
			}
		}
		else
		{
			if (Application.loadedLevel != 0)
			{
				if (action > 0)
				{
					Color newColor;
					//green player 1
					if (gameObject.name == "Player1")
					{
						newColor = new Color(0.4f,0.8f,0.3f);
					}
					//blue player 2
					else if (gameObject.name == "Player2")
					{
						newColor = new Color(0.15f,0.6f,1);
					}
					//pink player 3
					else if (gameObject.name == "Player3")
					{
						newColor = new Color(0.83f,0.32f,0.5f);
					}
					//yellow player 4
					else 
					{
						newColor = new Color(0.85f,0.82f,0.3f);
					}
					DeviceController.instance.Move(transform.position, newColor);

				}

				if (action2 > 0)
				{
					if (inventory.getInventoryItem() == null)
					{
						GameObject jumpItem = inventory.getAvailablItem();
						if (jumpItem != null)
						{
							JumpController.instance.addToBoxCollideCount();
							FloorInstructions.instance.ChangeInstructions();
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
						JumpController.instance.resetBoxCollideCount();
						inventory.getInventoryItem().transform.position = new Vector3(transform.localPosition.x,
						                                            					   1.5f,
						                                               					   transform.localPosition.z);
						inventory.getInventoryItem().transform.rotation = Quaternion.Euler(0,0,0);
						inventory.getInventoryItem().transform.parent = null;
						inventory.getInventoryItem().rigidbody.isKinematic = false;
						inventory.getInventoryItem().SendMessage("Leave");
						inventory.setAvailableItem(inventory.getInventoryItem());
						inventory.clearInventory();
						AudioController.instance.Play("006_Drop");
					}
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
			bool monsterAround = false;
			GameObject[] monsters = GameObject.FindGameObjectsWithTag ("Monster");
			foreach (GameObject monster in monsters)
			{
				if (Vector3.Distance(transform.position, monster.transform.position) < closeDistance)
				{
					monsterAround = true;
					break;
				}
			}
			if (!monsterAround)
			{
				foreach (GameObject player in players)
				{

					if ((!player.GetComponent<PlayerController>().isParalysed()) && 
						(Vector3.Distance(transform.localPosition, player.transform.localPosition) < closeDistance))
					{
						if (Time.time - timeFromLastRevive > timeBetweenRevivals)
						{
							gameController.SendMessage("PlayerReviwed");
							transform.GetChild(0).transform.GetChild(0).gameObject.renderer.materials[0].color = originalColor;
							collider.isTrigger = false;
							paralysed = false;
							AudioController.instance.Play("032_ReviveB");
							timeFromLastRevive = Time.time;
							break;
						}
					}
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
				AudioController.instance.Play("011_LightOn");
			}
		}
		if(collision.collider.name == "PortalGun")
		{
			if (!DroneController.instance.isEntered())
			{
				portalGunEntered = true;
				freeze();
				DroneController.instance.TurnOn();
				AudioController.instance.Play("011_LightOn");
			}
		}
		if(collision.collider.tag == "Monster")
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
				FloorInstructions.instance.ShowReviveInstructions();
				//collision.gameObject.SendMessage("Recalculate");
			}
		}
		if(collision.collider.name == "Platform")
		{
			levelChangeEntered = collision.collider.gameObject.GetComponent<LevelChangeController>();
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}

	void OnCollisionStay (Collision collision)
	{
		// if player jumps on the block its velocity shouldn't be zeroed, because he should slide
		if ((collision.collider.name == "Block") && (gameObject.rigidbody.useGravity == false))
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			collision.gameObject.SendMessage("Move", -collision.contacts[0].normal);
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
