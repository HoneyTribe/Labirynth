using UnityEngine;
using System.Collections;

public class MachineDoorsController : MonoBehaviour
{

	private int playersInBase = 0;
	private Animator lightDoorAnim;
	private Animator craneDoorAnim;
	private Animator dronetDoorAnim;
	private static int OpenDoorHash = Animator.StringToHash ("OpenDoor");
	private static int CloseDoorHash = Animator.StringToHash ("CloseDoor");

	void Start ()
	{
		//playersInBase =LevelFinishedController.instance.getControllers().Count;
		lightDoorAnim = GameObject.Find ("DoorLight").GetComponent<Animator> ();
		craneDoorAnim = GameObject.Find ("DoorCrane").GetComponent<Animator> ();
		dronetDoorAnim = GameObject.Find ("DoorDrone").GetComponent<Animator> ();
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInBase ++;

			if(playersInBase > 0 && TopLightController.instance.isEntered() == false)
			{
				OpenLightDoor();
			}

			if(LevelFInishedController.instance.isPickingUpEnabled() == true || LevelFInishedController.instance.isPickingUpEnabled() == true)
			{
				if(playersInBase > 0 && CraneController.instance.isEntered() == false)
				{	
					OpenCraneDoor();
				}
			}

			if(playersInBase > 0 && DroneController.instance.isEntered() == false)
			{
				OpenDroneDoor();
			}
		}
	}

	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInBase --;
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

	public void OpenLightDoor()
	{
		lightDoorAnim.SetTrigger(OpenDoor);
	}

	public void OpenCraneDoor()
	{
		craneDoorAnim.SetTrigger(OpenDoor);
	}

	public void OpenDroneDoor()
	{
		droneDoorAnim.SetTrigger(OpenDoor);
	}
}
