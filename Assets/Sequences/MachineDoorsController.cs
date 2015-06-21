using UnityEngine;
using System.Collections;

public class MachineDoorsController : MonoBehaviour
{
	public static MachineDoorsController instance;

	private int playersInBase = 0;
	private bool lightDoorOpen;
	private bool craneDoorOpen;
	private bool droneDoorOpen;
	private Animator lightDoorAnim;
	private Animator craneDoorAnim;
	private Animator droneDoorAnim;
	private static int OpenDoorHash = Animator.StringToHash ("OpenDoor");
	private static int CloseDoorHash = Animator.StringToHash ("CloseDoor");

	void Start ()
	{
		//playersInBase =LevelFinishedController.instance.getControllers().Count;
		instance = this;
		lightDoorAnim = GameObject.Find ("DoorLight").GetComponent<Animator> ();
		craneDoorAnim = GameObject.Find ("DoorCrane").GetComponent<Animator> ();
		droneDoorAnim = GameObject.Find ("DoorDrone").GetComponent<Animator> ();
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInBase ++;

			CanOpenLightDoor();

			if(LevelFinishedController.instance.isPickingUpEnabled() == true || LevelFinishedController.instance.isSmashingEnabled() == true)
			{
				CanOpenCraneDoor();
			}

			if(LevelFinishedController.instance.isStunGunEnabled() == true || LevelFinishedController.instance.isTeleportEnabled() == true)
			{
				CanOpenDroneDoor();
			}
		}
	}

	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInBase --;

			CanCloseLightDoor();

			if(LevelFinishedController.instance.isPickingUpEnabled() == true || LevelFinishedController.instance.isSmashingEnabled() == true)
			{
				CanCloseCraneDoor();
			}
			
			if(LevelFinishedController.instance.isStunGunEnabled() == true || LevelFinishedController.instance.isTeleportEnabled() == true)
			{
				CanCloseDroneDoor();
			}
		}
	}

	public void ReducePlayersInBase()
	{
		playersInBase --;
	}

	public void IncreasePlayersInBase()
	{
		playersInBase ++;
	}

	////////// light door ////////////

	private void CanOpenLightDoor()
	{
		//if(LevelFinishedController.instance.isDistractionEnabled() == true || LevelFinishedController.instance.isItemActivationEnabled() == true)
		//{
			if( playersInBase > 0 && TopLightController.instance.isEntered() == false)
			{	
			OpenLightDoor();
			}
		//}
	}
	
	public void OpenLightDoor()
	{
		if (lightDoorOpen == false)
		{
			lightDoorAnim.SetTrigger(OpenDoorHash);
			lightDoorOpen = true;
		}
	}

	private void CanCloseLightDoor()
	{
		if( playersInBase == 0 && TopLightController.instance.isEntered() == false)
		{	
			CloseLightDoor();
		}
	}

	// triggered from this script & PlayerController
	public void CloseLightDoor()
	{
		if(lightDoorOpen == true)
		{
			lightDoorAnim.SetTrigger(CloseDoorHash);
			lightDoorOpen = false;
		}
	}

	////////// crane door ////////////

	private void CanOpenCraneDoor()
	{
		if(playersInBase > 0 && CraneController.instance.isEntered() == false)
			{	
				OpenCraneDoor();
			}
	}

	// triggered from this script & PlayerController
	public void OpenCraneDoor()
	{
		if (craneDoorOpen == false)
		{
			craneDoorAnim.SetTrigger(OpenDoorHash);
			craneDoorOpen = true;
		}
	}

	private void CanCloseCraneDoor()
	{
		if( playersInBase == 0 && CraneController.instance.isEntered() == false)
		{	
			CloseCraneDoor();
		}
	}
	
	// triggered from this script & PlayerController
	public void CloseCraneDoor()
	{
		if(craneDoorOpen == true)
		{
			craneDoorAnim.SetTrigger(CloseDoorHash);
			craneDoorOpen = false;
		}
	}

	////////// drone door ////////////

	private void CanOpenDroneDoor()
	{
			if(playersInBase > 0 && DroneController.instance.isEntered() == false)
			{	
				OpenDroneDoor();
			}
	}

	public void OpenDroneDoor()
	{
		if(droneDoorOpen == false)
		{
			droneDoorAnim.SetTrigger(OpenDoorHash);
			droneDoorOpen = true;
		}
	}

	private void CanCloseDroneDoor()
	{
		if( playersInBase == 0 && DroneController.instance.isEntered() == false)
		{	
			CloseDroneDoor();
		}
	}
	
	// triggered from this script & PlayerController
	public void CloseDroneDoor()
	{
		if(droneDoorOpen == true)
		{
			droneDoorAnim.SetTrigger(CloseDoorHash);
			droneDoorOpen = false;
		}
	}

}
