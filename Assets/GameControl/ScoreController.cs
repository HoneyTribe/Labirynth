using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public static ScoreController instance;

	private int score;
	private int numberOfPlayers;

	private int randomNumber;

	private GameObject leftDoor;
	private GameObject rightDoor;
	private GameObject leftExitLight;
	private GameObject rightExitLight;
	private GameObject[] candleLights;
	private GameObject fusionLight;
	
	void Start()
	{ 
		instance = this;
		
		leftDoor = GameObject.Find ("LeftDoor");
		rightDoor = GameObject.Find ("RightDoor");
		leftExitLight = GameObject.Find ("winLightLeft");
		rightExitLight = GameObject.Find ("winLightRight");
		candleLights = GameObject.FindGameObjectsWithTag ("CandleLightTag");
		score = LevelFinishedController.instance.getNumberOfKeys ();
		numberOfPlayers = LevelFinishedController.instance.getControllers ().Count;
		fusionLight = GameObject.Find ("lightHousePointLight");
	}

	/*
	void OnGUI()
	{
		if (!LevelFinishedController.instance.isStopped())
		{
			GUI.Label (new Rect (Screen.width / 2 - 200, 40, 300, 100), "Keys to collect: " + score); 
		}
	}
	*/

	public void MinusScore()
	{
		score--;

		if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstLightLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstZapLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstTriggerLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstBlockLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDecoyLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.secondDecoyLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstCraneLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstJumpBoxLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneBombLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstCraneLazerLevel)
		{
			FloorInstructions.instance.ChangeInstructions();
		}

		if (score == 0)
		{
			AudioController.instance.Play("004_CollectLastKey");

			fusionLight.gameObject.SendMessage("TurnLightOn");
			//leftDoor.gameObject.SendMessage("OpenDoor");
			//rightDoor.gameObject.SendMessage("OpenDoor");
			//leftExitLight.gameObject.SendMessage("TurnLightOn");
			//rightExitLight.gameObject.SendMessage("TurnLightOn");
			//foreach (GameObject light in candleLights)
			//{
			//	light.gameObject.SendMessage("TurnLightOn");
			//}
			GameObject.Find ("GameController").SendMessage("ActivateFusion");
			
			string endingName = LevelFinishedController.instance.getEnding();
			if (endingName != null)
			{
				GameObject.Find ("EndingController").SendMessage(endingName);
			}

			PopTriggerContainer2.instance.movePopOnScreen();
		}
	}

	public void Score()
	{
			randomNumber = Random.Range(1,5);
			
			if (randomNumber == 1)
			{
				AudioController.instance.Play("a4");
				
			}
			
			else if (randomNumber == 2)
			{
				AudioController.instance.Play("d4");
				
			}
			
			else if (randomNumber == 3)
			{
				AudioController.instance.Play("f4");
				
			}
			
			else if (randomNumber == 4)
			{
				AudioController.instance.Play("c5");
				
			}
			
	}

	public void PlayerParalysed()
	{
		numberOfPlayers --; 
		FloorInstructions.instance.deadPlayersInstructions --;
		FloorInstructions.instance.ChangeInstructions();
		GameObject.Find ("MainCamera_Front").SendMessage ("StartEarthquake");
		if (numberOfPlayers == 0)
		{
			StartCoroutine(LevelFinishedController.instance.PlayerLost());
		}
	}

	public void PlayerReviwed()
	{
		numberOfPlayers ++;
		FloorInstructions.instance.deadPlayersInstructions ++;
		FloorInstructions.instance.ChangeInstructions();
	}

	public int getScore()
	{
		return score;
	}

	public int getNumberOfPlayers()
	{
		return numberOfPlayers;
	}
}
