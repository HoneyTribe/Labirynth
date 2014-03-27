using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode action;

	public float speed = 10;	

	private bool lighthouseEntered = false;

	private GameObject torch;
	private GameObject topLight;
	private GameObject levelController;
	private GameObject device;
	private LevelFinishedController levelFinishedController;

	private List<KeyCode> keys;

	void Start()
	{
		torch = GameObject.Find ("LightContainer");
		topLight = GameObject.Find ("TopLight");
		levelController = GameObject.Find ("LevelController");
		device = GameObject.Find ("Device");
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController>();
		keys = new List<KeyCode> ();
		//keys.Add (moveRight);
		//keys.Add (moveLeft);
	}

	// Update is called once per frame
	void Update () {

		if (levelFinishedController.isStopped())
		{
			return;
		}

		handleKeys ();

		int x = 0;
		int z = 0;
		for (int i=0; i < keys.Count; i++)
		{
			handleKeysLogic(i, ref x, ref z);
		}
		Vector3 aa = new Vector3(x, 0, z).normalized * speed;
		rigidbody.velocity = new Vector3(x, 0, z).normalized * speed;

		if (Input.GetKeyUp (action) && (lighthouseEntered)) 
		{
			topLight.gameObject.SendMessage("AttractMonster");
		}

		if ((!lighthouseEntered) && (Input.GetKeyUp (action)))
		{
			device.gameObject.SendMessage("Move", transform.localPosition);
		}
	}

	private void handleKeys()
	{
		if (Input.GetKeyDown (moveUp))
		{
			keys.Add(moveUp);
		}
		else if (Input.GetKeyUp (moveUp))
		{
			keys.Remove(moveUp);
		}

		if (Input.GetKeyDown (moveDown))
		{
			keys.Add(moveDown);
		}
		else if (Input.GetKeyUp (moveDown))
		{
			keys.Remove(moveDown);
		}

		if (Input.GetKeyDown (moveLeft))
		{
			keys.Add(moveLeft);
		}
		else if (Input.GetKeyUp (moveLeft))
		{
			keys.Remove(moveLeft);
		}

		if (Input.GetKeyDown (moveRight))
		{
			keys.Add(moveRight);
		}
		else if (Input.GetKeyUp (moveRight))
		{
			keys.Remove(moveRight);
		}
	}

	private void handleKeysLogic(int i, ref int x, ref int z)
	{
		if (keys[i] == moveUp)
		{
			z = 1;
			if (lighthouseEntered)
			{
				lighthouseEntered = false;
				topLight.gameObject.SendMessage("TurnOff");
			}
		}
		else if (keys[i] == moveDown)
		{
			z = -1;
		}
		else if(keys[i] == moveLeft)
		{
			if (lighthouseEntered)
			{
				torch.gameObject.SendMessage("MoveLeft");
			}
			else
			{
				x = -1; 
			}
		}
		else if(keys[i] == moveRight)
		{
			if (lighthouseEntered)
			{
				torch.gameObject.SendMessage("MoveRight");
			}
			else
			{
				x = 1;
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
