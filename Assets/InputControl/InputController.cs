using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;

public class InputController {

	public static float BUTTON_DURATION = 0.8f;
	public static float MIN_BUTTON_DURATION = 0.2f;

	public int playerId;

	private PlayerController playerController;
	private MenuController menuController;
	private PlayerSelectionMenuController playerSelectionMenuController;

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode actionTrigger;
	public KeyCode actionTrigger2;

	private InputDevice device;
	private bool keyboard;
	private bool left;

	private List<KeyCode> keys;
	private bool menuButtonPressed;
	private bool playerMenuButtonPressed;

	private float actionTime;
	private float action2Time;

	private float actionAxisTime;
	private float actionAxis2Time;

	private bool actionAxisBlocked;

	public InputController(InputDevice device, bool keyboard, bool left, PlayerSelectionMenuController playerSelectionMenuController,
	                       int playerId)
	{
		this.device = device;
		this.keyboard = keyboard;
		this.left = left;
		this.playerSelectionMenuController = playerSelectionMenuController;

		//this.playerController = GameObject.Find ("Player" + playerId).GetComponent<PlayerController> ();
		this.playerId = playerId;
		keys = new List<KeyCode> ();
		updatePlayer ();
		InControlManager.instance.join ();
		GameObject o = GameObject.Find ("GameObject" + playerId);
		o.GetComponent<MeshRenderer>().enabled = true;
		//keys.Add (moveRight);
		//keys.Add (moveLeft);
	}

	public void React ()
	{
		float x = 0;
		float z = 0;
		float action = 0;
		float action2 = 0;
		handleAxis (ref x, ref z, ref action, ref action2);
		//handleKeys (ref x, ref z, ref action, ref action2);

		if (IntroductionController.instance != null && IntroductionController.instance.isPlayingIntroduction())
		{
			if ((action > 0) || (action2 > 0))
			{
				IntroductionController.instance.StopIntroduction(true);
			}
		}
		else
		{
			handleMenu(action, action2);
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

		if ((actionTime != 0) && ((Input.GetKeyUp (actionTrigger)) || (Time.time - actionTime > BUTTON_DURATION)))
		{
			action = Time.time - actionTime;
			actionTime = 0f;
		}

		if (Input.GetKeyDown (actionTrigger2))
		{
			action2Time = Time.time;
		}

		if ((action2Time != 0) && ((Input.GetKeyUp (actionTrigger2)) || (Time.time - action2Time > BUTTON_DURATION)))
		{
			action2 = Time.time - action2Time;
			action2Time = 0f;
		}

		//handleKeysActions (ref x, ref z);
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
		//if (InputManager.Devices.Count > device)
		{
			InputDevice inputDevice = device;

			float actionAxis;
			InputControl action2control;
			if (left)
			{
				x = inputDevice.LeftStickX.Value;
				z = inputDevice.LeftStickY.Value;
				actionAxis = inputDevice.LeftTrigger.Value;
				action2control = inputDevice.LeftBumper;
			}
			else
			{
				x = inputDevice.RightStickX.Value;
				z = inputDevice.RightStickY.Value;
				actionAxis = inputDevice.RightTrigger.Value;
				action2control = inputDevice.RightBumper;
			}


			if ((actionAxisTime == 0f) && (actionAxis > 0f))
			{
				actionAxisTime = Time.time;
			}

			if ((actionAxisTime != 0f) && ((actionAxis == 0f) || (Time.time - actionAxisTime >= BUTTON_DURATION)))
			{
				if (!actionAxisBlocked)
				{
					action = Time.time - actionAxisTime;
					if (Time.time - actionAxisTime >= BUTTON_DURATION)
					{
						actionAxisBlocked = true;
					}
				}

				if (actionAxis == 0f)
				{
					actionAxisBlocked = false;
					actionAxisTime = 0f;
				}
			}

			if (action2control.WasPressed)
			{
				actionAxis2Time = Time.time;
			}

			if ((actionAxis2Time != 0f) && ((action2control.WasReleased) || (Time.time - actionAxis2Time > BUTTON_DURATION)))
			{
				action2 = Time.time - actionAxis2Time;
				actionAxis2Time = 0f;
			}
		}
	}

	private void handleMenu(float action, float action2)
	{
		if (Application.loadedLevel != 0)
		{
			if (!LevelFinishedController.instance.IsInstruction())
			{
				if (device.GetControl(InputControlType.Start).WasPressed)
				{
					LevelFinishedController.instance.ShowInstruction();
				}
			}
			else
			{
				if (device.GetControl(InputControlType.Start).WasPressed)
				{
					LevelFinishedController.instance.HideInstruction();
				}
			}
		}
	}

	public void SetMenu(MenuController menuController)
	{
		this.menuController = menuController;
	}

	public InputDevice getDevice()
	{
		return device;
	}

	public bool isKeyboard()
	{
		return keyboard;
	}

	public bool isLeft()
	{
		return left;
	}

	public int getPlayerId()
	{
		return playerId;
	}

	public void updatePlayer()
	{
		GameObject player = GameObject.Find ("Player" + playerId);
		playerController = player.GetComponent<PlayerController> ();
	}
}
