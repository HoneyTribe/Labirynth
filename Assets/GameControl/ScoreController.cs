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

	public void Score()
	{
		score--;

		if(LevelFinishedController.instance.getLevel() == 0 || LevelFinishedController.instance.getLevel() == 1 ||
		  LevelFinishedController.instance.getLevel() == 5 || LevelFinishedController.instance.getLevel() == 8 ||
		   LevelFinishedController.instance.getLevel() == 11)
		{
			FloorInstructions.instance.ChangeInstructions();
		}

		if (score == 0)
		{
			AudioController.instance.Play("004_CollectLastKey");

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
		}
		else
		{
			randomNumber = Random.Range(1,4);

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
}
