using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode actionTrigger;

	public string horizontalAxis;
	public string verticalAxis;
	public string triggerAxis;

	public float speed = 8;	

	private bool lighthouseEntered = false;

	private GameObject topLight;
	private GameObject levelController;
	private GameObject device;
	private LevelFinishedController levelFinishedController;

	private List<KeyCode> keys;
	private bool actionAxisInUse;

	void Start()
	{
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

		float x = 0;
		float z = 0;
		float action = 0;
		handleAxis (ref x, ref z, ref action);
		handleKeys (ref x, ref z, ref action);
		handleLogic(x, z, action);

		if (!lighthouseEntered)
		{
			rigidbody.velocity = new Vector3(x, 0, z).normalized * speed;
		}
	}

	private void handleKeys(ref float x, ref float z, ref float action)
	{
		if (!Input.anyKey)
		{
			keys.Clear();
		}

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

		if (Input.GetKeyUp (actionTrigger))
		{
			action = 1;
		}

		handleKeysActions (ref x, ref z, ref action);
	}

	private void handleKeysActions(ref float x, ref float z, ref float action)
	{
		for (int i=0; i < keys.Count; i++)
		{
			if (keys[i] == moveUp)
			{
				z = 1;
			}
			else if (keys[i] == moveDown)
			{
				z = -1;
			}
			else if(keys[i] == moveLeft)
			{
				x = -1; 
			}
			else if(keys[i] == moveRight)
			{
				x = 1;
			}
		}
	}

	private void handleAxis(ref float x, ref float z, ref float action)
	{
		x = Input.GetAxis (horizontalAxis) * Time.deltaTime;
		z = Input.GetAxis (verticalAxis) * Time.deltaTime;
		float actionAxis = Input.GetAxis (triggerAxis);

		if ((!actionAxisInUse) && (actionAxis == 1.0f))
		{
			action = actionAxis * Time.deltaTime;
			actionAxisInUse = true;
		}

		if (actionAxis == -1.0f)
		{
			actionAxisInUse = false;
		}
	}

	private void handleLogic(float x, float z, float action)
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
			//Destroy(gameObject);
			gameObject.transform.Translate(gameObject.transform.localPosition.x * 10, 0, 0);
			levelController.gameObject.SendMessage("PlayerFinished");
		}
		if((collision.collider.name == "Monster(Clone)") ||
 		   (collision.collider.name == "FlyingMonster(Clone)"))
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
		return actionTrigger;
	}
}
