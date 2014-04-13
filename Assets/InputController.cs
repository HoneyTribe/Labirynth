using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputController : MonoBehaviour {

	public GameObject player;
	private PlayerController playerController;
	private MenuController menuController;

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode actionTrigger;
	public KeyCode actionTrigger2;

	public string horizontalAxis;
	public string verticalAxis;
	public string triggerAxis;
	public string triggerButton;

	private List<KeyCode> keys;
	private bool menuButtonPressed;

	private float actionTime;
	private float action2Time;

	private float actionAxisTime;
	private float actionAxis2Time;

	void Start()
	{
		playerController = player.GetComponent<PlayerController> ();
		keys = new List<KeyCode> ();
		//keys.Add (moveRight);
		//keys.Add (moveLeft);
	}

	// Update is called once per frame
	void Update ()
	{
		float x = 0;
		float z = 0;
		float action = 0;
		float action2 = 0;
		handleAxis (ref x, ref z, ref action, ref action2);
		handleKeys (ref x, ref z, ref action, ref action2);

		if (menuController != null)
		{
			if ((x == 0) && (z == 0) && (action == 0) && (action2 == 0))
			{
				menuButtonPressed = false;
			}
			else
			{
				if (!menuButtonPressed)
				{
					menuButtonPressed = true;
					menuController.handleLogic (x, z, action, action2);
				}
			}
		}
		else
		{
			playerController.handleLogic (x, z, action, action2);
		}
	}

	private void handleKeys(ref float x, ref float z, ref float action, ref float action2)
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

		/////////////////ACTIONS///////////////

		if (Input.GetKeyDown (actionTrigger))
		{
			actionTime = Time.time;
		}

		if (Input.GetKeyUp (actionTrigger))
		{
			action = Time.time - actionTime;
			actionTime = 0f;
		}

		if (Input.GetKeyDown (actionTrigger2))
		{
			action2Time = Time.time;
		}

		if (Input.GetKeyUp (actionTrigger2))
		{
			action2 = Time.time - action2Time;
			action2Time = 0f;
		}

		handleKeysActions (ref x, ref z);
	}

	private void handleKeysActions(ref float x, ref float z)
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

	private void handleAxis(ref float x, ref float z, ref float action, ref float action2)
	{
		x = Input.GetAxis (horizontalAxis) * Time.deltaTime;
		z = Input.GetAxis (verticalAxis) * Time.deltaTime;
		float actionAxis = Input.GetAxis (triggerAxis);

		if ((actionAxisTime != 0f) && (actionAxis == 1.0f))
		{
			actionAxisTime = Time.time;
		}

		if (actionAxis == -1.0f)
		{
			action = Time.time - actionAxisTime;
			actionAxisTime = 0f;
		}

		if (Input.GetButtonDown(triggerButton))
		{
			actionAxis2Time = Time.time;
		}

		if (Input.GetButtonUp(triggerButton))
		{
			action2 = Time.time - actionAxis2Time;
			actionAxis2Time = 0f;
		}
	}

	public void SetMenu(MenuController menuController)
	{
		this.menuController = menuController;
	}
}
