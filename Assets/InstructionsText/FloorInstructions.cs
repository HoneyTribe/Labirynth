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
	private float textOffScreen = -1f;
	private TextMesh instructions;
	private GameObject robot;
	private int showedReviveInstructions = 0;


	//These need to be changed in the interface attached to the object TextInstructionsFloor in Main Scene
	// If changed you also need to change MoveToMachine() values in PlayerController
	public int firstLightLevel = 0;
	public int firstBlockLevel = 11;
	public int firstZapLevel = 2;
	public int firstDecoyLevel = 3;
	public int secondDecoyLevel = 4;
	public int firstChaseLevel = 5;
	public int firstDoorLevel = 6;
	public int firstGhostLevel = 7;
	public int firstCraneLevel = 8;
	public int firstTriggerLevel = 1;
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
		instructions = GetComponentInChildren<TextMesh>();
		robot = GameObject.Find ("Player5");
	}

	//Called from ScoreController, TopLightController, DeviceController, DroneController, JumpController
	public void ChangeInstructions ()
	{	
		//light
		if(LevelFinishedController.instance.getLevel() == firstLightLevel)
		{
			if(robot == null) // multiplayer
			{
				if (TopLightController.instance.isEntered() == true)
				{
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);

					if (ScoreController.instance.getScore() > 0)
					{
						instructions.text = "The maze runners can collect all the energy.";
					}
					else
					{
						instructions.text = "Hold action-1 to exit the machine and then high-five.";
						//controlImagePad1Move.transform.position = new Vector3(-0.3f, 1f, -6f);
					}
				}
				else
				{
					if (ScoreController.instance.getScore() > 0)
					{
						instructions.text = "Walk into          the light.";
						arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
					}
					else
					{
						instructions.text = "Everybody High-five together to time-shift.";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}
				}
			}
			else // 1-player
			{
				if (TopLightController.instance.isEntered() == true)
				{
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					
					if (ScoreController.instance.getScore() > 0)
					{
						instructions.text = "The maze runner can collect all the energy.";
					}
					else
					{
						instructions.text = "High-five together to time-shift.";
						//controlImagePad1Move.transform.position = new Vector3(-0.3f, 1f, -6f);
					}
				}
			}
		}
		//first block
		/*
		else if(LevelFinishedController.instance.getLevel() == firstBlockLevel)
		{
			if (TopLightController.instance.isEntered() == true)
			{
				arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				
				if (ScoreController.instance.getScore() > 0)
				{
					instructions.text = "";
				}
				else
				{
					instructions.text = "Hold action-1 to exit the machine and then high-five.";
					//controlImagePad1Move.transform.position = new Vector3(-0.3f, 1f, -4.5f);
				}
			}
			
			else
				if (ScoreController.instance.getScore() > 0)
			{
				instructions.text = "Walk into          the light.";
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -14);
			}
			else
			{
				instructions.text = "Everybody High-Five together to time-shift.";
				arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
			}
		}
		*/
		// zap tut
		else if(LevelFinishedController.instance.getLevel() == firstZapLevel)
		{
			arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);

				if(TopLightController.instance.isEntered() == true
				   && ScoreController.instance.getScore() > 0)
				{
					if(TopLightController.instance.getZapCount() == 0)
					{
						instructions.text = "Hypnotize the mummy. Aim at the mummy and tap action-1.";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}
					
					else if(TopLightController.instance.getZapCount() == 1)
					{
						instructions.text = "Zap! He's walking towards the decoy...";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}
					
					else
					{
						instructions.text = "Life-forms try to walk to the decoy when hypnotized.";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}
				}
				else if(ScoreController.instance.getScore() > 0
				        && TopLightController.instance.isEntered() == false)
				{
					instructions.text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				}
				else if (TopLightController.instance.isEntered() == true // multiplayer
			         && ScoreController.instance.getScore() == 0
			         && robot == null)
				{
					instructions.text = "Hold action-1 to exit the machine and then high-five.";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
				else if (TopLightController.instance.isEntered() == true // 1-player
				         && ScoreController.instance.getScore() == 0
				         && robot != null)
				{
					instructions.text = "High-five together to time-shift.";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
				else if (ScoreController.instance.getScore() == 0
				         && TopLightController.instance.isEntered() == false)
				{
					instructions.text = "Everybody High-Five together to time-shift.";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
				else
				{
					instructions.text = "";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
		}

		// first decoy level
		else if(LevelFinishedController.instance.getLevel() == firstDecoyLevel)
		{
			arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);

			if (deadPlayersInstructions == 0) //nobody dead
			{	
				if(TopLightController.instance.isEntered() == true
				   && ScoreController.instance.getScore() > 0)
				{
					if(TopLightController.instance.getZapCount() % 2 == 0
					   && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
					instructions.text = "Walk in the maze and tap action-1 to move the Decoy.";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}

					else if(TopLightController.instance.getZapCount() % 2 == 1
					   && DeviceController.instance.getDecoyCount() % 2 == 1)
					{
						instructions.text = "You can reposition the Decoy. Tap action-1 when in the maze.";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}

					else if(TopLightController.instance.getZapCount() % 2 == 1
					        && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
						instructions.text = "Hypnotize the mummies. Aim at them and tap action-1.";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}

					else
					{
						instructions.text = "Hypnotize the mummies. Aim at them and tap action-1.";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}
				}
				else if(ScoreController.instance.getScore() > 0
				        && TopLightController.instance.isEntered() == false)
				{
					instructions.text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				}
				else if (TopLightController.instance.isEntered() == true
				         && ScoreController.instance.getScore() == 0
				         && robot == null) //multiplayer
				{
					instructions.text = "Hold action-1 to exit the machine and then high-five.";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
				else if (TopLightController.instance.isEntered() == true
				         && ScoreController.instance.getScore() == 0
				         && robot != null) // 1-player
				{
					instructions.text = "High-five together to time-shift.";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
				else if (ScoreController.instance.getScore() == 0
				         && TopLightController.instance.isEntered() == false)
				{
					instructions.text = "Everybody High-Five together to time-shift.";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
				else
				{
					instructions.text = "";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
			}
			else //someone dead
			{
				instructions.text = "Touch friends to revive them. First move the mummy!";
				arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
			}
		}

		// second decoy level
		else if(LevelFinishedController.instance.getLevel() == secondDecoyLevel)
		{
			arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
			
			if (deadPlayersInstructions == 0) //nobody dead
			{	
				if(TopLightController.instance.isEntered() == true
				   && ScoreController.instance.getScore() > 0)
				{
					if(TopLightController.instance.getZapCount() % 2 == 0
					   && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
						instructions.text = "Don't leave the Decoy behind the space machine!";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}
					
					else if(TopLightController.instance.getZapCount() % 2 == 1
					        && DeviceController.instance.getDecoyCount() % 2 == 1)
					{
						instructions.text = "Put the Decoy in strategic places.";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}
					
					else if(TopLightController.instance.getZapCount() % 2 == 1
					        && DeviceController.instance.getDecoyCount() % 2 == 0)
					{
						instructions.text = "Hazards are temporaily hypnotized when zapped.";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}
					
					else
					{
						instructions.text = "Each time you zap the power is depleted temporarily.";
						arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
					}
				}
				else if(ScoreController.instance.getScore() > 0
				        && TopLightController.instance.isEntered() == false)
				{
					instructions.text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				}
				else if (TopLightController.instance.isEntered() == true
				         && ScoreController.instance.getScore() == 0
				         && robot == null) // multiplayer
				{
					instructions.text = "Hold action-1 to exit the machine and then high-five.";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
				else
				{
					instructions.text = "";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
			}
			else //someone dead
			{
				if(robot == null) // multiplayer
				{
					instructions.text = "Touch friends to revive them. First move the mummy!";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);

				}
			}
		}
		//1st crane level
		else if(LevelFinishedController.instance.getLevel() == firstCraneLevel)
		{
			if(robot == null) // multiplayer
			{
				if(CraneController.instance.isEntered() == true)
				{
					instructions.text = "Push up to extend. Tap action-1 to pick up/drop things.";
					arrowRight.transform.position = new Vector3(4, textOffScreen, -13);
				}
				else
				{
					instructions.text = "Walk into the Grabber         entrance";
					arrowRight.transform.position = new Vector3(4, textOnScreen, -13);
				}
			}
			else // 1-player
			{
				if(CraneController.instance.isEntered() == true)
				{
					instructions.text = "Push up to extend. Tap action-1 to pick up/drop things.";
					arrowRight.transform.position = new Vector3(4, textOffScreen, -13);
				}

				if (TopLightController.instance.isEntered() == true)
				{
					instructions.text = "Hold down action-1 to exit/switch machines.";
					arrowRight.transform.position = new Vector3(4, textOffScreen, -13);
				}
			}
		}
		//1st drone level
		else if(LevelFinishedController.instance.getLevel() == firstDroneLevel)
		{
			if(robot == null) // multiplayer
			{
				if(DroneController.instance.isEntered() == true)
				{
					instructions.text = "Fly the teleport Drone. Tap Action-1 to drop teleports.";
					arrowLeft.transform.position = new Vector3(-4, textOffScreen, -13);
				}
				else
				{
					instructions.text = "Walk into             the Drone entrance";
					arrowLeft.transform.position = new Vector3(-4, textOnScreen, -13);
				}
			}
			else // 1-player
			{
				if(DroneController.instance.isEntered() == true)
				{
					instructions.text = "Fly the teleport Drone. Tap Action-1 to drop teleports.";
					arrowLeft.transform.position = new Vector3(-4, textOffScreen, -13);
				}
				if (TopLightController.instance.isEntered() == true)
				{
					instructions.text = "Hold down action-1 to exit/switch machines.";
					arrowLeft.transform.position = new Vector3(4, textOffScreen, -13);
				}
			}
		}
		//trigger
		else if(LevelFinishedController.instance.getLevel() == firstTriggerLevel)
		{
			if (TopLightController.instance.isEntered() == true)
			{
				arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				
				if (ScoreController.instance.getScore() > 0)
				{
					instructions.text = "";
				}
				else
				{
					if(robot == null) //multiplayer
					{
						instructions.text = "Hold action-1 to exit the machine and then high-five.";
					}
					else // 1-player
					{
						instructions.text = "High-Five together to time-shift.";
					}
				}
			}
			else
			{
				if (ScoreController.instance.getScore() > 0)
				{
					instructions.text = "Walk into          the light.";
					arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				}
				else
				{
					instructions.text = "Everybody High-Five together to time-shift.";
					arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
				}
			}
		}

		//1st jump box level
		else if(LevelFinishedController.instance.getLevel() == firstJumpBoxLevel)
		{
			if(JumpController.instance.GetBoxCollideCount() > 0 && ScoreController.instance.getScore() > 0)
			{
				instructions.text = "Tap action-2 to pick up or drop items.";
			}
			else if(JumpController.instance.GetBoxCollideCount() <= 0 && ScoreController.instance.getScore() > 0 && TopLightController.instance.isEntered() == true)
			{
				instructions.text = "Aim at your BFF and tap action-2 while they're on the Box.";
			}
			else if( ScoreController.instance.getScore() == 0)
			{
				instructions.text = "You can practice using the anti-grav box here safely.";
			}
		}
		//1st drone bomb level
		else if(LevelFinishedController.instance.getLevel() == firstDroneBombLevel)
		{
			if(robot == null) // multiplayer
			{
				if(DroneController.instance.isEntered() == true && ScoreController.instance.getScore() > 0)
				{
					instructions.text = "Fly the teleport Drone. Tap Action-2 and drop stun bombs.";
					arrowLeft.transform.position = new Vector3(-4, textOffScreen, -13);
				}
				else if (DroneController.instance.isEntered() == false && ScoreController.instance.getScore() > 0)
				{
					instructions.text = "Walk into             the Drone entrance";
					arrowLeft.transform.position = new Vector3(-4, textOnScreen, -13);
				}
				else
				{
					instructions.text = "";
					arrowLeft.transform.position = new Vector3(-4, textOffScreen, -13);
				}
			}
			else // 1-player
			{
				if(DroneController.instance.isEntered() == true && ScoreController.instance.getScore() > 0)
				{
					instructions.text = "Fly the teleport Drone. Tap Action-2 and drop stun bombs.";
					arrowLeft.transform.position = new Vector3(-4, textOffScreen, -13);
				}
				if (TopLightController.instance.isEntered() == true)
				{
					instructions.text = "Hold down action-1 to exit/switch machines.";
					arrowLeft.transform.position = new Vector3(-4, textOffScreen, -13);
				}
			}
		}
		//1st crane lazer level
		else if(LevelFinishedController.instance.getLevel() == firstCraneLazerLevel)
		{
			if(robot == null) // multiplayer
			{
				if(CraneController.instance.isEntered() == true && ScoreController.instance.getScore() > 0)
				{
					instructions.text = "If at 100% power tap action-2 when above walls.";
					arrowRight.transform.position = new Vector3(4, textOffScreen, -13);
				}
				else if (CraneController.instance.isEntered() == false && ScoreController.instance.getScore() > 0)
				{
					instructions.text = "Walk into the Wall-Lazer           entrance";
					arrowRight.transform.position = new Vector3(4, textOnScreen, -13);
				}
				else
				{
					instructions.text = "";
					arrowRight.transform.position = new Vector3(4, textOffScreen, -13);
				}
			}
			else //1-player
			{
				if(CraneController.instance.isEntered() == true && ScoreController.instance.getScore() > 0)
				{
					instructions.text = "If at 100% power tap action-2 when above walls.";
					arrowRight.transform.position = new Vector3(4, textOffScreen, -13);
				}
				if (TopLightController.instance.isEntered() == true)
				{
					instructions.text = "Hold down action-1 to exit/switch machines.";
					arrowRight.transform.position = new Vector3(-4, textOffScreen, -13);
				}
			}

		}

	}

	//Text to display after intro
	//Called from Introduction Controller
	public void Activate ()
	{	
		if(robot == null) //multiplayer
		{
			//light
			if (LevelFinishedController.instance.getLevel() == firstLightLevel)
			{
				instructions.text = "Walk into          the light";
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
			}
			//1st block
			/*
			if (LevelFinishedController.instance.getLevel() == firstBlockLevel)
			{
				instructions.text = "Walk into          the light";
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
			}
			*/
			//1st zap
			if (LevelFinishedController.instance.getLevel() == firstZapLevel)
			{
				instructions.text = "Walk into          the light";
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				//controlImagePad1Move.transform.position = new Vector3(-0.3f, 1f, -6f);
			}
			//trigger
			if (LevelFinishedController.instance.getLevel() == firstTriggerLevel)
			{
				instructions.text = "Walk into          the light";
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
			}
			//decoy
			if (LevelFinishedController.instance.getLevel() == firstDecoyLevel)
			{
				instructions.text = "Walk into          the light";
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
				//controlImagePad1Move.transform.position = new Vector3(-0.3f, 1f, 2f);
			}
			// 2nd decoy
			if (LevelFinishedController.instance.getLevel() == secondDecoyLevel)
			{
				instructions.text = "Walk into          the light";
				arrowCentre.transform.position = new Vector3(0, textOnScreen, -13);
			}
			//crane
			else if (LevelFinishedController.instance.getLevel() == firstCraneLevel)
			{
				instructions.text = "Walk into the Grabber         entrance";
				arrowRight.transform.position = new Vector3(4, textOnScreen, -13);
			}
			//drone
			else if (LevelFinishedController.instance.getLevel() == firstDroneLevel)
			{
				instructions.text = "Walk into             the Drone entrance";
				arrowLeft.transform.position = new Vector3(-4, textOnScreen, -13);
			}
			//jump box
			else if (LevelFinishedController.instance.getLevel() == firstJumpBoxLevel)
			{
				instructions.text = "Go and pick up the Anti-Grav Box";
				//controlImagePad2Move.transform.position = new Vector3(-0.3f, 1f, 1f);
			}
			//drone bomb
			else if (LevelFinishedController.instance.getLevel() == firstDroneBombLevel)
			{
				instructions.text = "Walk into             the Drone entrance";
				arrowLeft.transform.position = new Vector3(-4, textOnScreen, -13);
				//controlImagePad2Move.transform.position = new Vector3(-2.3f, 1f, 0f);
			}
			//crane lazer
			else if (LevelFinishedController.instance.getLevel() == firstCraneLazerLevel)
			{
				instructions.text = "Walk into the Wall-Lazer           entrance";
				arrowRight.transform.position = new Vector3(4, textOnScreen, -13);
				//controlImagePad2Move.transform.position = new Vector3(-0.3f, 1f, -3.5f);
			}
		}
		else
		{
			//jump box
			if (LevelFinishedController.instance.getLevel() == firstJumpBoxLevel)
			{
				instructions.text = "Go and pick up the Anti-Grav Box";
			}
		}

	}
	//Called from LevelFinishedController
	public void Remove () //off screen
	{
		instructions.text = "";
		arrowLeft.transform.position = new Vector3(-4, textOffScreen, -13);
		arrowRight.transform.position = new Vector3(4, textOffScreen, -13);
		arrowCentre.transform.position = new Vector3(0, textOffScreen, -13);
	}

	// Called from PlayerController
	public void ShowReviveInstructions() 
	{
		LevelFinishedController.instance.setDeadCount();
		/*
		if (LevelFinishedController.instance.getDeadCount() <= deadCountMax
		    && showedReviveInstructions == 0
		    && robot == null)
		{
			//controlImagePad1Move.transform.position = new Vector3(-0.3f, -1f, -6f);
			//controlImagePad1Move.transform.position = new Vector3(-0.3f, -1f, -6f);
			co_reviveAlert.transform.position = new Vector3(0f, 1f, -6f);
			showedReviveInstructions ++;
		}
		*/

	}

	public int GetReviveInstructions()
	{
		return showedReviveInstructions;
	}
}