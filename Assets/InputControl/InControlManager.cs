using UnityEngine;
using System.Collections.Generic;
using InControl;

public class InControlManager : MonoBehaviour {

	public static InControlManager instance;
	private PlayerSelectionMenuController playerSelectionMenuController;

	private int currentPlayer;

	void Start ()
	{
		InputManager.Setup ();

//		List<InputDevice> devicesToDetach = new List<InputDevice> ();
//		if (SystemInfo.operatingSystem.ToUpper().Contains("WINDOWS"))
//		{
//			bool detachNext = false;
//			for (int i = 0; i < InputManager.Devices.Count; i++)
//			{
//				InputDevice input = InputManager.Devices[i];
//				if ((input.Name == "XBox 360 Controller") && (!detachNext))
//				{
//					detachNext = true;
//					continue;
//				}
//				if (detachNext)
//				{
//					devicesToDetach.Add(input);
//					detachNext = false;
//				}
//			}
//		}

		InputManager.AttachDevice( new UnityInputDevice( new KeyboardProfile1() ) );
		InputManager.AttachDevice( new UnityInputDevice( new KeyboardProfile2() ) );
		InputManager.AttachDevice( new UnityInputDevice( new CustomProfile() ) );

//		foreach(InputDevice device in InputManager.Devices)
//		{
//			Debug.Log("Attached device:" + device.Name);
//		}
//		
//		foreach(InputDevice device in devicesToDetach)
//		{
//			InputManager.DetachDevice(device);
//			Debug.Log("Detached device:" + device.Name);
//		}

		foreach(InputController inputController in LevelFinishedController.instance.getControllers())
		{
			inputController.updatePlayer();
		}

		for (int i = LevelFinishedController.instance.getControllers().Count + 1; i <= 4; i++)
		{
			GameObject.Find ("Player" + i).SetActive(false);
		}

		instance = this;
	}

	void Update () 
	{
		InputManager.Update ();

		if (playerSelectionMenuController != null)
		{
			InputDevice input = InputManager.ActiveDevice;
			if (input.GetControl(InputControlType.Select).WasPressed)
			{
				if (playerSelectionMenuController.getSplash() == 0)
				{
					playerSelectionMenuController.setSplash(2);
					currentPlayer = 1;
					LevelFinishedController.instance.getControllers().Clear();
					return;
				}
				else if (playerSelectionMenuController.getSplash() == 2)
				{
					playerSelectionMenuController.setSplash(1);
					return;
				}
				else
				{
					Application.Quit();
				}
			}
			if ((input.GetControl(InputControlType.LeftTrigger).WasPressed) ||
			    (input.GetControl(InputControlType.LeftBumper).WasPressed) ||
			    (input.GetControl(InputControlType.RightTrigger).WasPressed) ||
			    (input.GetControl(InputControlType.RightBumper).WasPressed) ||
				(input.GetControl(InputControlType.Action1).WasPressed) ||
			    (input.GetControl(InputControlType.Action2).WasPressed) ||
			    (input.GetControl(InputControlType.Action3).WasPressed) ||
			    (input.GetControl(InputControlType.Start).WasPressed) )
			{
				if (playerSelectionMenuController.getSplash() == 2)
				{
					playerSelectionMenuController.setSplash(0);
					return;
				}
				else if (playerSelectionMenuController.getSplash() == 1)
				{
					playerSelectionMenuController.setSplash(2);
					return;
				}
			}

			bool left = false;
			bool right = false;
			if ((input.GetControl(InputControlType.LeftTrigger).WasPressed) || (input.GetControl(InputControlType.LeftBumper).WasPressed))
			{
				left = true;
			}
			if ((input.GetControl(InputControlType.RightTrigger).WasPressed) || (input.GetControl(InputControlType.RightBumper).WasPressed))
			{
				right = true;
			}

			bool keyboard = input.Meta.Contains("keyboard");
			bool found  = false;

			// hasChanged to avoid key holding
			if (left || right)
			{
				foreach(InputController inputController in LevelFinishedController.instance.getControllers())
				{
					if ((inputController.getDevice() == getDeviceId(input)) && (inputController.isLeft() == left))
					{
						found = true;
					}
				}
				if (!found)
				{
					if (LevelFinishedController.instance.getControllers().Count != 4)
					{
						LevelFinishedController.instance.getControllers().Add(
							new InputController(getDeviceId(input), keyboard, left, playerSelectionMenuController, currentPlayer++));
					}
				}
			}
		}

		foreach(InputController input in LevelFinishedController.instance.getControllers())
		{
			input.React();
		}
	}

	public void SetPlayerSelectionMenu(PlayerSelectionMenuController playerSelectionMenuController)
	{
		currentPlayer = 1;
		this.playerSelectionMenuController = playerSelectionMenuController;
	}

	public void RemovePlayerSelectionMenu()
	{
		this.playerSelectionMenuController = null;
	}

	private int getDeviceId(InputDevice inputDevice)
	{
		for (int i = 0; i < InputManager.Devices.Count; i++)
		{
			if (InputManager.Devices[i].Meta == inputDevice.Meta)
			{
				return i;
			}
		}

		throw new UnityException("Can't find device = " + inputDevice.Meta);
	}
}
