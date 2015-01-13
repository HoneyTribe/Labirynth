using UnityEngine;
using System.Collections;

public class FloorInstructions : MonoBehaviour
{
	public static FloorInstructions instance;
	
	private GameObject arrowCentre;
	private GameObject arrowRight;
	private GameObject arrowLeft;
	public int deadPlayersInstructions;

	// Reads variables from: LevelFinishedController.cs, DeviceController.cs, ScoreController.cs, TopLightController.cs, CraneController.cs
	
	void Start()
	{
		instance = this;
		arrowCentre = GameObject.Find ("ArrowCentre");
		arrowRight = GameObject.Find ("ArrowRight");
		arrowLeft = GameObject.Find ("ArrowLeft");
	}

	//Called from ScoreController, TopLightController, DeviceController, DroneController
	public void ChangeInstructions ()
	{	
		//level1
		if(LevelFinishedController.instance.getLevel() == 0)
		{
			if (TopLightController.instance.isEntered() == true)
			{
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);

				if (ScoreController.instance.getScore() > 0)
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine.";
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine.";
				}
			}

			else
				if (ScoreController.instance.getScore() > 0)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light";
					arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time-shift";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
		}
		//level 2
		else if(LevelFinishedController.instance.getLevel() == 1)
		{
			arrowCentre.transform.position = new Vector3(0, -0.5f, -13);

			if (deadPlayersInstructions == 0) //nobody dead
			{
				if(DeviceController.instance.isDeviceInLighthouse() == true
				   && ScoreController.instance.getScore() > 0
				   && TopLightController.instance.isEntered() == true)
				{
					GetComponentInChildren<TextMesh>().text = "Maze-runners: Tap action-1 to move the Decoy.";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
				else if(ScoreController.instance.getScore() > 0
				   		&& TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light";
					arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
				}
				else if (DeviceController.instance.isDeviceInLighthouse() == false
				         && TopLightController.instance.isEntered() == true)
				{
					GetComponentInChildren<TextMesh>().text = "Aim the light at monsters and tap action-1. Zap to distract.";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
				else if (ScoreController.instance.getScore() == 0
				         && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time-shift";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
			}
			else //someone dead
			{
				GetComponentInChildren<TextMesh>().text = "Revive your fallen friends by touching them.";
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
			}
		}
		//level6
		else if(LevelFinishedController.instance.getLevel() == 5)
		{
			if(CraneController.instance.isEntered() == true)
			{
				GetComponentInChildren<TextMesh>().text = "Push up to extend. Tap action-1 to pick up/drop things.";
				arrowRight.transform.position = new Vector3(4, -0.5f, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "Walk into the Grabber         entrance";
				arrowRight.transform.position = new Vector3(4, 0.5f, -13);
			}
		}
		//level9
		else if(LevelFinishedController.instance.getLevel() == 8)
		{
			if(DroneController.instance.isEntered() == true)
			{
				GetComponentInChildren<TextMesh>().text = "Fly the teleport Drone. Tap Action-1 to drop teleports.";
				arrowLeft.transform.position = new Vector3(-4, -0.5f, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "Walk into              the Drone entrance";
				arrowLeft.transform.position = new Vector3(-4, 0.5f, -13);
			}
		}	



	
	}

	//Text after intro.
	//Called from Introduction Controller.cs in public void StopIntroduction(bool stopping) at approx line 132
	public void Activate ()
	{	
		//level1
		if (LevelFinishedController.instance.getLevel() == 0)
			{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
			}
		//level2
		if (LevelFinishedController.instance.getLevel() == 1)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
		}
		//level6
		else if (LevelFinishedController.instance.getLevel() == 5)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into the Grabber         entrance";
			arrowRight.transform.position = new Vector3(4, 0.5f, -13);
		}
		//level9
		else if (LevelFinishedController.instance.getLevel() == 8)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into             the Drone entrance";
			arrowLeft.transform.position = new Vector3(-4, 0.5f, -13);
		}


	}
}