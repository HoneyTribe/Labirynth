﻿using UnityEngine;
using System.Collections;

public class FloorInstructions : MonoBehaviour
{
	public static FloorInstructions instance;
	
	private GameObject arrowCentre;
	private GameObject arrowRight;
	private GameObject arrowLeft;
	public int deadPlayersInstructions;

	//These are attached to the object TextInstructionsFloor
	public int firstLightLevel = 0;
	public int firstBlockLevel = 1;
	public int firstZapLevel = 2;
	public int firstDecoyLevel = 3;
	public int secondDecoyLevel = 4;
	public int firstDoorLevel = 6;
	public int firstGhostLevel = 7;
	public int firstCraneLevel = 8;
	public int firstTriggerLevel = 11;
	public int firstDroneLevel = 14;
	public int firstJumpBoxLevel = 17;
	public int firstDroneBombLevel = 23;
	public int firstCraneLazerLevel = 26;

	// Reads variables from: LevelFinishedController.cs, DeviceController.cs, ScoreController.cs, TopLightController.cs, CraneController.cs
	
	void Start()
	{
		instance = this;
		arrowCentre = GameObject.Find ("ArrowCentre");
		arrowRight = GameObject.Find ("ArrowRight");
		arrowLeft = GameObject.Find ("ArrowLeft");
	}

	//Called from ScoreController, TopLightController, DeviceController, DroneController, JumpController
	public void ChangeInstructions ()
	{	
		//light
		if(LevelFinishedController.instance.getLevel() == firstLightLevel)
		{
			if (TopLightController.instance.isEntered() == true)
			{
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);

				if (ScoreController.instance.getScore() > 0)
				{
					GetComponentInChildren<TextMesh>().text = "The maze runners can collect all the energy.";
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
				}
			}

			else
				if (ScoreController.instance.getScore() > 0)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time-shift.";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
		}
		//first block
		else if(LevelFinishedController.instance.getLevel() == firstBlockLevel)
		{
			if (TopLightController.instance.isEntered() == true)
			{
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				
				if (ScoreController.instance.getScore() > 0)
				{
					GetComponentInChildren<TextMesh>().text = "";
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
				}
			}
			
			else
				if (ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
				arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "High-five with all players to time-shift.";
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
			}
		}
		// zap tut
		else if(LevelFinishedController.instance.getLevel() == firstZapLevel)
		{
			arrowCentre.transform.position = new Vector3(0, -0.5f, -13);

				if(TopLightController.instance.isEntered() == true
				   && ScoreController.instance.getScore() > 0)
				{
					if(TopLightController.instance.getZapCount() == 0)
					{
						GetComponentInChildren<TextMesh>().text = "Hypnotize the mummy. Aim the light at it and tap action 1.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}
					
					else if(TopLightController.instance.getZapCount() == 1)
					{
						GetComponentInChildren<TextMesh>().text = "Zap! Good, now you can collect the energy safely.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}
					
					else
					{
						GetComponentInChildren<TextMesh>().text = "Life-forms try to walk to the decoy when they are hypnotized.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}
				}
				else if(ScoreController.instance.getScore() > 0
				        && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
				}
				else if (TopLightController.instance.isEntered() == true
				         && ScoreController.instance.getScore() == 0)
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
				else if (ScoreController.instance.getScore() == 0
				         && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time shift.";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
		}

		// first decoy level
		else if(LevelFinishedController.instance.getLevel() == firstDecoyLevel)
		{
			arrowCentre.transform.position = new Vector3(0, -0.5f, -13);

			if (deadPlayersInstructions == 0) //nobody dead
			{	
				if(TopLightController.instance.isEntered() == true
				   && ScoreController.instance.getScore() > 0)
				{
					if(TopLightController.instance.getZapCount() % 2 == 0
					   && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
					GetComponentInChildren<TextMesh>().text = "Walk in the maze and tap action-1 to move the Decoy.";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}

					else if(TopLightController.instance.getZapCount() % 2 == 1
					   && DeviceController.instance.getDecoyCount() % 2 == 1)
					{
						GetComponentInChildren<TextMesh>().text = "You can reposition the Decoy by tapping action-1 in the maze.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}

					else if(TopLightController.instance.getZapCount() % 2 == 1
					        && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
						GetComponentInChildren<TextMesh>().text = "Hypnotize the mummies. Aim the light at them and tap action-1.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}

					else
					{
						GetComponentInChildren<TextMesh>().text = "Hypnotize the mummies. Aim the light at them and tap action-1.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}
				}
				else if(ScoreController.instance.getScore() > 0
				        && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
				}
				else if (TopLightController.instance.isEntered() == true
				         && ScoreController.instance.getScore() == 0)
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
				else if (ScoreController.instance.getScore() == 0
				         && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time shift.";
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
				GetComponentInChildren<TextMesh>().text = "Revive your friends by touching them. Avoid mummies!";
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
			}
		}

		// second decoy level
		else if(LevelFinishedController.instance.getLevel() == secondDecoyLevel)
		{
			arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
			
			if (deadPlayersInstructions == 0) //nobody dead
			{	
				if(TopLightController.instance.isEntered() == true
				   && ScoreController.instance.getScore() > 0)
				{
					if(TopLightController.instance.getZapCount() % 2 == 0
					   && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
						GetComponentInChildren<TextMesh>().text = "Don't leave the Decoy behind the light-controller.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}
					
					else if(TopLightController.instance.getZapCount() % 2 == 1
					        && DeviceController.instance.getDecoyCount() % 2 == 1)
					{
						GetComponentInChildren<TextMesh>().text = "Put the Decoy in cunning places.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}
					
					else if(TopLightController.instance.getZapCount() % 2 == 1
					        && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
						GetComponentInChildren<TextMesh>().text = "Hazards are temporaily mind-controlled when zapped.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}
					
					else
					{
						GetComponentInChildren<TextMesh>().text = "Each time you zap the power is depleted temporarily.";
						arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
					}
				}
				else if(ScoreController.instance.getScore() > 0
				        && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
				}
				else if (TopLightController.instance.isEntered() == true
				         && ScoreController.instance.getScore() == 0)
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
					arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				}
				else if (ScoreController.instance.getScore() == 0
				         && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time shift.";
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
				GetComponentInChildren<TextMesh>().text = "Revive your friends by touching them. Avoid hazards!";
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
			}
		}
		//1st crane level
		else if(LevelFinishedController.instance.getLevel() == firstCraneLevel)
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
		//1st drone level
		else if(LevelFinishedController.instance.getLevel() == firstDroneLevel)
		{
			if(DroneController.instance.isEntered() == true)
			{
				GetComponentInChildren<TextMesh>().text = "Fly the teleport Drone. Tap Action-1 to drop teleports.";
				arrowLeft.transform.position = new Vector3(-4, -0.5f, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "Walk into             the Drone entrance";
				arrowLeft.transform.position = new Vector3(-4, 0.5f, -13);
			}
		}
		//trigger
		else if(LevelFinishedController.instance.getLevel() == firstTriggerLevel)
		{
			if (TopLightController.instance.isEntered() == true)
			{
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
				
				if (ScoreController.instance.getScore() > 0)
				{
					GetComponentInChildren<TextMesh>().text = "What does that button over there do?";
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
				}
			}
			
			else
				if (ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
				arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "High-five with all players to time-shift.";
				arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
			}
		}

		//1st jump box level
		else if(LevelFinishedController.instance.getLevel() == firstJumpBoxLevel)
		{
			if(JumpController.instance.GetBoxCollideCount() > 0 && ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "Tap action-2 to pick up or drop items.";
			}
			else if(JumpController.instance.GetBoxCollideCount() <= 0 && ScoreController.instance.getScore() > 0 && TopLightController.instance.isEntered() == true)
			{
				GetComponentInChildren<TextMesh>().text = "Aim the light at your BFF and tap action-2 while they're on the Box.";
			}
			else if( ScoreController.instance.getScore() == 0)
			{
				GetComponentInChildren<TextMesh>().text = "You can practice using the anti-grav box here safely.";
			}
		}
		//1st drone bomb level
		else if(LevelFinishedController.instance.getLevel() == firstDroneBombLevel)
		{
			if(DroneController.instance.isEntered() == true && ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "Fly the teleport Drone. Tap Action-2 and drop stun bombs.";
				arrowLeft.transform.position = new Vector3(-4, -0.5f, -13);
			}
			else if (DroneController.instance.isEntered() == false && ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "Walk into             the Drone entrance";
				arrowLeft.transform.position = new Vector3(-4, 0.5f, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "";
				arrowLeft.transform.position = new Vector3(-4, -0.5f, -13);
			}
		}
		//1st crane level
		else if(LevelFinishedController.instance.getLevel() == firstCraneLazerLevel)
		{
			if(CraneController.instance.isEntered() == true && ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "If at 100% power tap action-2 when above walls.";
				arrowRight.transform.position = new Vector3(4, -0.5f, -13);
			}
			else if (CraneController.instance.isEntered() == false && ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "Walk into the Wall-Lazer           entrance";
				arrowRight.transform.position = new Vector3(4, 0.5f, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "";
				arrowRight.transform.position = new Vector3(4, -0.5f, -13);
			}
		}

	}

	//Text to display after intro
	//Called from Introduction Controller
	public void Activate ()
	{	
		//light
		if (LevelFinishedController.instance.getLevel() == firstLightLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
		}
		//1st block
		if (LevelFinishedController.instance.getLevel() == firstBlockLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
		}
		//1st zap
		if (LevelFinishedController.instance.getLevel() == firstZapLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
		}
		//trigger
		if (LevelFinishedController.instance.getLevel() == firstTriggerLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
		}
		//decoy
		if (LevelFinishedController.instance.getLevel() == firstDecoyLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
		}
		// 2nd decoy
		if (LevelFinishedController.instance.getLevel() == secondDecoyLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, 0.5f, -13);
		}
		//crane
		else if (LevelFinishedController.instance.getLevel() == firstCraneLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into the Grabber         entrance";
			arrowRight.transform.position = new Vector3(4, 0.5f, -13);
		}
		//drone
		else if (LevelFinishedController.instance.getLevel() == firstDroneLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into             the Drone entrance";
			arrowLeft.transform.position = new Vector3(-4, 0.5f, -13);
		}
		//jump box
		else if (LevelFinishedController.instance.getLevel() == firstJumpBoxLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Go and pick up the Anti-Grav Box";
		}
		//drone bomb
		else if (LevelFinishedController.instance.getLevel() == firstDroneBombLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into             the Drone entrance";
			arrowLeft.transform.position = new Vector3(-4, 0.5f, -13);
		}
		//crane lazer
		else if (LevelFinishedController.instance.getLevel() == firstCraneLazerLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into the Wall-Lazer           entrance";
			arrowRight.transform.position = new Vector3(4, 0.5f, -13);
		}

	}
	//Called from LevelFinishedController
	public void Remove () //off screen
	{
		GetComponentInChildren<TextMesh>().text = "";
		arrowLeft.transform.position = new Vector3(-4, -0.5f, -13);
		arrowRight.transform.position = new Vector3(4, -0.5f, -13);
		arrowCentre.transform.position = new Vector3(0, -0.5f, -13);
	}
}