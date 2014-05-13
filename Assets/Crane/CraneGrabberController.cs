using UnityEngine;
using System.Collections;

public class CraneGrabberController : MonoBehaviour {

	private float grabberSpeed = 10f;

	private Vector3 grabberPosition;
	private Vector3 newGrabberPosition;
	private bool pickingUp;
	private bool smashing;

	private GameObject heldObject;
	private GameObject smashedWall;

	public GameObject flamePrefab;

	void Update()
	{
		if (pickingUp)
		{
			float distance = Vector3.Distance(transform.position, newGrabberPosition);
			
			if (distance != 0)
			{
				transform.position = Vector3.Lerp (
					transform.position, newGrabberPosition, Time.deltaTime * grabberSpeed / distance);
			}
			else
			{
				this.newGrabberPosition = this.grabberPosition;
				if (transform.position.Equals(this.grabberPosition))
				{
					pickingUp = false;
				}
			}
		}

		// hanlde in next frame
		if ((smashing) && (smashedWall == null))
		{
			smashing = false;
			AstarPath.active.Scan();
		}
	}

	public void PickUp() 
	{
		if (LevelFinishedController.instance.getLevel() >= LevelFinishedController.instance.getFirstLevelWithCrane())
		{
			if (!pickingUp)
			{
				if ((heldObject == null) && (CraneEnergyController.instance.canPickUp()))
				{
					this.newGrabberPosition = new Vector3 (transform.position.x, 
					                                       transform.position.y - 7,
					                                       transform.position.z);
					this.grabberPosition = transform.position;
					this.pickingUp = true;
					CraneEnergyController.instance.pickingUp();
				}
				else
				{
					heldObject.rigidbody.useGravity = true;
					heldObject.transform.parent = null;
					heldObject.rigidbody.velocity = new Vector3(0, -10, 0);
					if (heldObject.tag == "Item")
					{
						// check groundController
						heldObject.collider.isTrigger = false;
						Physics.IgnoreLayerCollision(LayerMask.NameToLayer("players"), LayerMask.NameToLayer("item"), true);
						Physics.IgnoreLayerCollision(LayerMask.NameToLayer("monsters"), LayerMask.NameToLayer("item"), true);
						Physics.IgnoreLayerCollision(LayerMask.NameToLayer("flyingMonsters"), LayerMask.NameToLayer("item"), true);
					}
					CraneEnergyController.instance.holding(false);
					heldObject = null;
				}
			}
		}
	}

	public void Smash() 
	{
		if (LevelFinishedController.instance.getLevel() >= LevelFinishedController.instance.getFirstLevelWithSmasher())
		{
			if (!smashing)
			{
				if ((heldObject == null) && (CraneEnergyController.instance.canSmash()))
				{
					RaycastHit hit;
					if (Physics.SphereCast(transform.position, 1f, Vector3.down, out hit))
					{
						if ((hit.collider.tag == "Wall") || (hit.collider.tag == "Pillar"))
						{
							smashedWall = hit.collider.gameObject;
							GameObject flame = (GameObject) Instantiate (flamePrefab, hit.point, Quaternion.Euler(0, 0, 0)); 
							flame.transform.parent = smashedWall.transform;
							this.smashing = true;
							CraneEnergyController.instance.smashing();
						}
					}
				}
			}
		}
	}

	void DestroyWall()
	{
		Destroy (smashedWall);
	}
	
	void OnTriggerEnter (Collider collider)
	{
		this.newGrabberPosition = this.grabberPosition;
		if ((collider.tag == "Monster") || (collider.tag == "Item") || (collider.tag == "Player"))
		{
			if ((heldObject == null) && (pickingUp))
			{
				GameObject obj = collider.gameObject;
				if (obj.transform.parent != null)
				{
					obj = obj.transform.parent.gameObject;
				}
				obj.rigidbody.useGravity = false;
				obj.rigidbody.velocity = Vector3.zero;
				obj.transform.parent = transform;
				if ((obj.tag == "Player") || (obj.tag == "Monster"))
				{
					obj.gameObject.SendMessage("setStopped", true);
				}
				heldObject = obj;
				CraneEnergyController.instance.holding(true);
			}
		}
	}

	public bool isPickingUp()
	{
		return pickingUp;
	}

	public bool isSmashing()
	{
		return smashing;
	}
}
