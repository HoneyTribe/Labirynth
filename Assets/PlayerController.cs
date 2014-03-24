using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode action;

	public float speed = 10;	

	private bool lighthouseEntered = false;
	private bool readyToAttract = false;

	private GameObject torch;
	private GameObject topLight;
	private GameObject levelController;
	private GameObject device;
	private LevelFinishedController levelFinishedController;

	void Start()
	{
		torch = GameObject.Find ("LightContainer");
		topLight = GameObject.Find ("TopLight");
		levelController = GameObject.Find ("LevelController");
		device = GameObject.Find ("Device");
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController>();
	}

	// Update is called once per frame
	void Update () {

		if (levelFinishedController.isStopped())
		{
			return;
		}

		if (Input.GetKey (moveUp))
		{
			rigidbody.velocity = new Vector3(0, 0, speed);
			if (lighthouseEntered)
			{
				lighthouseEntered = false;
				readyToAttract = false;
				topLight.gameObject.SendMessage("TurnOff");
			}
		} 
		else if (Input.GetKey (moveDown))
		{	
			if (readyToAttract)
			{
				topLight.gameObject.SendMessage("AttractMonster");
			}
			else
			{
				rigidbody.velocity = new Vector3(0, 0, -speed);
			}
		}
		else if (Input.GetKeyUp (moveDown) && (lighthouseEntered))
		{
			readyToAttract = true;
		}
		else if (Input.GetKey (moveLeft))
		{
			if (lighthouseEntered)
			{
				torch.gameObject.SendMessage("MoveLeft");
			}
			else
			{
				rigidbody.velocity = new Vector3(-speed, 0, 0);
			}
		}
		else if (Input.GetKey (moveRight))
		{
			if (lighthouseEntered)
			{
				torch.gameObject.SendMessage("MoveRight");
			}
			else
			{
				rigidbody.velocity = new Vector3(speed, 0, 0);
			}
		}
		else 
		{
			rigidbody.velocity = new Vector3(0, 0, 0);
		}

		if ((!lighthouseEntered) && (Input.GetKeyUp (action)))
		{
			device.gameObject.SendMessage("Move", transform.localPosition);
		}

		/*if (Input.GetKey (moveUp))
		{
			moveDirection = new Vector3(0, 0, 1);
		} 
		else if (Input.GetKey (moveDown))
		{
			moveDirection = new Vector3(0, 0, -1);
		}
		else if (Input.GetKey (moveLeft))
		{
			moveDirection = new Vector3(-1, 0, 0);
		}
		else if (Input.GetKey (moveRight))
		{
			moveDirection = new Vector3(1, 0, 0);
		}
		else 
		{
			moveDirection = new Vector3(0, 0, 0);
		}


		//moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		controller.Move(moveDirection * Time.deltaTime);*/
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
			topLight.gameObject.SendMessage("TurnOn");
		}
		if(collision.collider.name == "ExitTrigger")
		{
			//Destroy(gameObject);
			gameObject.transform.Translate(gameObject.transform.localPosition.x * 10, 0, 0);
			levelController.gameObject.SendMessage("PlayerFinished");
		}
		if(collision.collider.name == "Monster(Clone)")
		{
			levelController.gameObject.SendMessage("PlayerLost");
		}
	}

	public KeyCode getLeft()
	{
		return moveLeft;
	}

	public KeyCode getRight()
	{
		return moveRight;
	}

	public KeyCode getAction()
	{
		return action;
	}
}
