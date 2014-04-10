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

	void Start()
	{
		speed *= LevelFinishedController.instance.gameSpeed;
		topLight = GameObject.Find ("TopLight");
		levelController = GameObject.Find ("LevelController");
		device = GameObject.Find ("Device");
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController>();
	}

	public void handleLogic(float x, float z, float action)
	{
		if ((z > 0) && (x == 0))
		{
			if (lighthouseEntered)
			{
				lighthouseEntered = false;
				topLight.gameObject.SendMessage("TurnOff");
				rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
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
				topLight.gameObject.SendMessage("AttractMonster");
			}
			else
			{
				device.gameObject.SendMessage("Move", transform.localPosition);
			}
		}

		if (!lighthouseEntered)
		{
			rigidbody.velocity = new Vector3(x, 0, z).normalized * speed;
			if ((x != 0) || (z != 0))
			{
				transform.rotation = Quaternion.LookRotation(new Vector3(x, 0, z)); 
			}
		}
	}

	public bool hasEnteredLighthouse()
	{
		return lighthouseEntered;
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
