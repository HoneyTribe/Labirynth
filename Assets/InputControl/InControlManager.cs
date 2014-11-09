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
			if (input.MenuWasPressed)
			{
				playerSelectionMenuController.setSplash(true);
				return;
			}
			bool left = (input.LeftTrigger.Value != 0) || (input.LeftBumper.Value != 0);
			bool right = (input.RightTrigger.Value != 0) || (input.RightBumper.Value != 0);
			bool keyboard = input.Meta.Contains("keyboard");
			bool found  = false;

			if (left || right)
			{
				if (playerSelectionMenuController.isSplash())
				{
					playerSelectionMenuController.setSplash(false);
					return;
				}
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
