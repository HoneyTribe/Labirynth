using UnityEngine;
using System.Collections;

public class FloorInstructions : MonoBehaviour
{
	public static FloorInstructions instance;
	
	private GameObject arrowCentre;
	private GameObject arrowRight;
	private GameObject arrowLeft;
	private GameObject controlImagePad1Move;
	private GameObject controlImagePad2Move;
	private GameObject co_reviveAlert;
	public int deadPlayersInstructions;// triggered in ScoreController
	private int deadCountMax = 3; // number of character deaths for revive alert to no longer display.
	private float textOnScreen = 1f;


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
		controlImagePad1Move = GameObject.Find ("ControlImagePad1Move");
		controlImagePad2Move = GameObject.Find ("ControlImagePad2Move");
		co_reviveAlert = GameObject.Find ("Co_ReviveAlert");
	}

	//Called from ScoreController, TopLightController, DeviceController, DroneController, JumpController
	public void ChangeInstructions ()
	{	
		//light
		if(LevelFinishedController.instance.getLevel() == firstLightLevel)
		{
			if (TopLightController.instance.isEntered() == true)
			{
				arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);

				if (ScoreController.instance.getScore() > 0)
				{
					GetComponentInChildren<TextMesh>().text = "The maze runners can collect all the energy.";
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
					controlImagePad1Move.transform.position = new Vector3(-0.3f, 1f, -6f);
				}
			}

			else
				if (ScoreController.instance.getScore() > 0)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time-shift.";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
		}
		//first block
		else if(LevelFinishedController.instance.getLevel() == firstBlockLevel)
		{
			if (TopLightController.instance.isEntered() == true)
			{
				arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				
				if (ScoreController.instance.getScore() > 0)
				{
					GetComponentInChildren<TextMesh>().text = "";
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
					controlImagePad1Move.transform.position = new Vector3(-0.3f, 1f, -4.5f);
				}
			}
			
			else
				if (ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -14);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "High-five with all players to time-shift.";
				arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
			}
		}
		// zap tut
		else if(LevelFinishedController.instance.getLevel() == firstZapLevel)
		{
			arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);

				if(TopLightController.instance.isEntered() == true
				   && ScoreController.instance.getScore() > 0)
				{
					if(TopLightController.instance.getZapCount() == 0)
					{
						GetComponentInChildren<TextMesh>().text = "Hypnotize the mummy. Aim at the mummy and tap action-1.";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}
					
					else if(TopLightController.instance.getZapCount() == 1)
					{
						GetComponentInChildren<TextMesh>().text = "Zap! Good, now you can collect the energy safely.";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}
					
					else
					{
						GetComponentInChildren<TextMesh>().text = "Life-forms try to walk to the decoy when they are hypnotized.";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}
				}
				else if(ScoreController.instance.getScore() > 0
				        && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				}
				else if (TopLightController.instance.isEntered() == true
				         && ScoreController.instance.getScore() == 0)
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
				else if (ScoreController.instance.getScore() == 0
				         && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time shift.";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
		}

		// first decoy level
		else if(LevelFinishedController.instance.getLevel() == firstDecoyLevel)
		{
			arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);

			if (deadPlayersInstructions == 0) //nobody dead
			{	
				if(TopLightController.instance.isEntered() == true
				   && ScoreController.instance.getScore() > 0)
				{
					if(TopLightController.instance.getZapCount() % 2 == 0
					   && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
					GetComponentInChildren<TextMesh>().text = "Walk in the maze and tap action-1 to move the Decoy.";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}

					else if(TopLightController.instance.getZapCount() % 2 == 1
					   && DeviceController.instance.getDecoyCount() % 2 == 1)
					{
						GetComponentInChildren<TextMesh>().text = "You can reposition the Decoy. Tap action-1 when in the maze.";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}

					else if(TopLightController.instance.getZapCount() % 2 == 1
					        && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
						GetComponentInChildren<TextMesh>().text = "Hypnotize the mummies. Aim at them and tap action-1.";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}

					else
					{
						GetComponentInChildren<TextMesh>().text = "Hypnotize the mummies. Aim at them and tap action-1.";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}
				}
				else if(ScoreController.instance.getScore() > 0
				        && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				}
				else if (TopLightController.instance.isEntered() == true
				         && ScoreController.instance.getScore() == 0)
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
				else if (ScoreController.instance.getScore() == 0
				         && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time shift.";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
			}
			else //someone dead
			{
				GetComponentInChildren<TextMesh>().text = "Revive your friends by touching them but first move the mummy!";
				arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
			}
		}

		// second decoy level
		else if(LevelFinishedController.instance.getLevel() == secondDecoyLevel)
		{
			arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
			
			if (deadPlayersInstructions == 0) //nobody dead
			{	
				if(TopLightController.instance.isEntered() == true
				   && ScoreController.instance.getScore() > 0)
				{
					if(TopLightController.instance.getZapCount() % 2 == 0
					   && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
						GetComponentInChildren<TextMesh>().text = "Don't leave the Decoy behind the space machine!";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}
					
					else if(TopLightController.instance.getZapCount() % 2 == 1
					        && DeviceController.instance.getDecoyCount() % 2 == 1)
					{
						GetComponentInChildren<TextMesh>().text = "Put the Decoy in strategic places.";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}
					
					else if(TopLightController.instance.getZapCount() % 2 == 1
					        && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
						GetComponentInChildren<TextMesh>().text = "Hazards are temporaily mind-controlled when zapped.";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}
					
					else
					{
						GetComponentInChildren<TextMesh>().text = "Each time you zap the power is depleted temporarily.";
						arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
					}
				}
				else if(ScoreController.instance.getScore() > 0
				        && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				}
				else if (TopLightController.instance.isEntered() == true
				         && ScoreController.instance.getScore() == 0)
				{
					GetComponentInChildren<TextMesh>().text = "Hold action-1 to exit the machine and then high-five.";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
				else if (ScoreController.instance.getScore() == 0
				         && TopLightController.instance.isEntered() == false)
				{
					GetComponentInChildren<TextMesh>().text = "High-five with all players to time shift.";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
				else
				{
					GetComponentInChildren<TextMesh>().text = "";
					arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				}
			}
			else //someone dead
			{
				GetComponentInChildren<TextMesh>().text = "Revive your friends by touching them but first move the mummy!";
				arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
			}
		}
		//1st crane level
		else if(LevelFinishedController.instance.getLevel() == firstCraneLevel)
		{
			if(CraneController.instance.isEntered() == true)
			{
				GetComponentInChildren<TextMesh>().text = "Push up to extend. Tap action-1 to pick up/drop things.";
				arrowRight.transform.position = new Vector3(4, -textOnScreen, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "Walk into the Grabber         entrance";
				arrowRight.transform.position = new Vector3(4, textOnScreen, -13);
			}
		}
		//1st drone level
		else if(LevelFinishedController.instance.getLevel() == firstDroneLevel)
		{
			if(DroneController.instance.isEntered() == true)
			{
				GetComponentInChildren<TextMesh>().text = "Fly the teleport Drone. Tap Action-1 to drop teleports.";
				arrowLeft.transform.position = new Vector3(-4, -textOnScreen, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "Walk into             the Drone entrance";
				arrowLeft.transform.position = new Vector3(-4, textOnScreen, -13);
			}
		}
		//trigger
		else if(LevelFinishedController.instance.getLevel() == firstTriggerLevel)
		{
			if (TopLightController.instance.isEntered() == true)
			{
				arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
				
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
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "High-five with all players to time-shift.";
				arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
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
				arrowLeft.transform.position = new Vector3(-4, -textOnScreen, -13);
			}
			else if (DroneController.instance.isEntered() == false && ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "Walk into             the Drone entrance";
				arrowLeft.transform.position = new Vector3(-4, textOnScreen, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "";
				arrowLeft.transform.position = new Vector3(-4, -textOnScreen, -13);
			}
		}
		//1st crane level
		else if(LevelFinishedController.instance.getLevel() == firstCraneLazerLevel)
		{
			if(CraneController.instance.isEntered() == true && ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "If at 100% power tap action-2 when above walls.";
				arrowRight.transform.position = new Vector3(4, -textOnScreen, -13);
			}
			else if (CraneController.instance.isEntered() == false && ScoreController.instance.getScore() > 0)
			{
				GetComponentInChildren<TextMesh>().text = "Walk into the Wall-Lazer           entrance";
				arrowRight.transform.position = new Vector3(4, textOnScreen, -13);
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "";
				arrowRight.transform.position = new Vector3(4, -textOnScreen, -13);
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
			arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
		}
		//1st block
		if (LevelFinishedController.instance.getLevel() == firstBlockLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
		}
		//1st zap
		if (LevelFinishedController.instance.getLevel() == firstZapLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
			controlImagePad1Move.transform.position = new Vector3(-0.3f, 1f, -6f);
		}
		//trigger
		if (LevelFinishedController.instance.getLevel() == firstTriggerLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
		}
		//decoy
		if (LevelFinishedController.instance.getLevel() == firstDecoyLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
			controlImagePad1Move.transform.position = new Vector3(-0.3f, 1f, -6f);
		}
		// 2nd decoy
		if (LevelFinishedController.instance.getLevel() == secondDecoyLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into          the light";
			arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
		}
		//crane
		else if (LevelFinishedController.instance.getLevel() == firstCraneLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into the Grabber         entrance";
			arrowRight.transform.position = new Vector3(4, textOnScreen, -13);
		}
		//drone
		else if (LevelFinishedController.instance.getLevel() == firstDroneLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into             the Drone entrance";
			arrowLeft.transform.position = new Vector3(-4, textOnScreen, -13);
		}
		//jump box
		else if (LevelFinishedController.instance.getLevel() == firstJumpBoxLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Go and pick up the Anti-Grav Box";
			controlImagePad2Move.transform.position = new Vector3(-0.3f, 1f, 1f);
		}
		//drone bomb
		else if (LevelFinishedController.instance.getLevel() == firstDroneBombLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into             the Drone entrance";
			arrowLeft.transform.position = new Vector3(-4, textOnScreen, -13);
			controlImagePad2Move.transform.position = new Vector3(-2.3f, 1f, 0f);
		}
		//crane lazer
		else if (LevelFinishedController.instance.getLevel() == firstCraneLazerLevel)
		{
			GetComponentInChildren<TextMesh>().text = "Walk into the Wall-Lazer           entrance";
			arrowRight.transform.position = new Vector3(4, textOnScreen, -13);
			controlImagePad2Move.transform.position = new Vector3(-0.3f, 1f, -3.5f);
		}

	}
	//Called from LevelFinishedController
	public void Remove () //off screen
	{
		GetComponentInChildren<TextMesh>().text = "";
		arrowLeft.transform.position = new Vector3(-4, -textOnScreen, -13);
		arrowRight.transform.position = new Vector3(4, -textOnScreen, -13);
		arrowCentre.transform.position = new Vector3(0, -textOnScreen, -13);
	}
	// Called from PlayerController
	public void ShowReviveInstructions() 
	{
		LevelFinishedController.instance.setDeadCount();
		if (LevelFinishedController.instance.getDeadCount() <= deadCountMax)
		{
			controlImagePad1Move.transform.position = new Vector3(-0.3f, -1f, -6f);
			controlImagePad1Move.transform.position = new Vector3(-0.3f, -1f, -6f);
			co_reviveAlert.transform.position = new Vector3(0f, 1f, -6f);
		}

	}
}