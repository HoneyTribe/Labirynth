using UnityEngine;
using System.Collections;

public class FloorInstructions : MonoBehaviour
{
	private ScoreController scoreController;
	private TopLightController topLightController;
	private LevelFinishedController levelFinishedController;
	private CraneController craneController;
	private GameObject arrowCentre;
	private GameObject arrowRight;
	public int deadPlayersInstructions;
	public int decoyInMaze;
	// Receives variables from DeviceController.cs, ScoreController.cs, CraneController.cs
	
	//public Texture instructionsFloor_02;
	
	void Start()
	{
		scoreController = GameObject.Find ("GameController").GetComponent<ScoreController> ();
		topLightController = GameObject.Find ("TopLight").GetComponent<TopLightController> ();
		craneController = GameObject.Find ("Neck").GetComponent<CraneController> ();
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController> ();
		arrowCentre = GameObject.Find ("ArrowCentre");
		arrowRight = GameObject.Find ("ArrowRight");
	}

	//Called from ScoreController.cs, TopLightController.cs, DeviceController.cs, CraneController.cs
	public void ChangeInstructions ()
	{	
		if(levelFinishedController.publicLevel == 0)
		{
			if (topLightController.enterLight == true)
			{
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);

				if (scoreController.publicScore > 0)
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine";
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine";
				}
			}

			else
				if (scoreController.publicScore > 0)
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

		else if(levelFinishedController.publicLevel == 1)
		{
			if (deadPlayersInstructions ==0) //nobody dead
			{
				if(decoyInMaze ==0)
				{
					GetComponentInChildren<TextMesh>().text = "Maze-runners: Tap action-1 to move the Decoy";
				}
				else if (decoyInMaze ==1 && topLightController.enterLight == true)
				{
					GetComponentInChildren<TextMesh>().text = "Aim the light at monsters and tap action-1. Zap to distract.";
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "";
				}
			}
			else //someone dead
			{
				GetComponentInChildren<TextMesh>().text = "Revive your fallen friends by touching them";
			}
		}
		else if(levelFinishedController.publicLevel == 5)
		{
			if(craneController.publicEnterCrane == true)
			{
				GetComponentInChildren<TextMesh>().text = "Extend with up and down. Tap action-1 to pick up/drop things.";
				arrowRight.transform.position = new Vector3(4, -0.5f, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "Walk into the Grabber         entrance";
				arrowRight.transform.position = new Vector3(4, 0.5f, -13);
			}
		}	

	}

	// Called in Introduction Controller.cs in public void StopIntroduction(bool stopping) at approx line 132
	public void Activate ()
	{
		if (levelFinishedController.publicLevel == 0)
			{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
			}
		else if (levelFinishedController.publicLevel == 5)
		{
			//GetComponentInChildren<TextMesh>().alignment = TextAlignment.Left;
			GetComponentInChildren<TextMesh>().text = "Walk into the Grabber         entrance";
			arrowRight.transform.position = new Vector3(4, 0.5f, -13);
		}
	}



}
//renderer.material.mainTexture = instructionsFloor_02;