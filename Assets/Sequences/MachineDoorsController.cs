using UnityEngine;
using System.Collections;

public class MachineDoorsController : MonoBehaviour
{
	public static MachineDoorsController instance;

	private int playersInBase = 0;
	private bool lightDoorOpen;
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
			print (playersInBase);

			CanOpenLightDoor();
			//OpenCraneDoor();
			//OpenDroneDoor();
		}
	}

	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInBase --;
			print (playersInBase);

			CanCloseLightDoor();
			//CloseCraneDoor();
			//CloseDroneDoor();
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
		//if(LevelFinishedController.instance.isDistractionEnabled() == true || LevelFinishedController.instance.isItemActivationEnabled() == true)
		//{
		if( playersInBase == 0 && TopLightController.instance.isEntered() == false)
		{	
			CloseLightDoor();
		}
		//}
	}

	// triggered from PlayerController
	public void CloseLightDoor()
	{
		if(lightDoorOpen == true)
		{
			lightDoorAnim.SetTrigger(CloseDoorHash);
			lightDoorOpen = false;
		}
	}



	private void CanOpenCraneDoor()
	{
		if(LevelFinishedController.instance.isPickingUpEnabled() == true || LevelFinishedController.instance.isSmashingEnabled() == true)
		{
			if(IntroductionController.instance.isPlayingIntroduction()== false && playersInBase > 0 && CraneController.instance.isEntered() == false)
			{	
				craneDoorAnim.SetTrigger(OpenDoorHash);
			}
		}
	}

	private void CanOpenDroneDoor()
	{
		if(LevelFinishedController.instance.isStunGunEnabled() == true || LevelFinishedController.instance.isTeleportEnabled() == true)
		{
			if(IntroductionController.instance.isPlayingIntroduction()== false && playersInBase > 0 && DroneController.instance.isEntered() == false)
			{	
				droneDoorAnim.SetTrigger(OpenDoorHash);
			}
		}
	}
}
