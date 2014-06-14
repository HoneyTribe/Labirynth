using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	private int score;
	private int numberOfPlayers;

	private GameObject leftDoor;
	private GameObject rightDoor;
	private GameObject leftExitLight;
	private GameObject rightExitLight;
	private GameObject[] candleLights;
	private GameObject fusionLight;
	
	void Start()
	{ 
		leftDoor = GameObject.Find ("LeftDoor");
		rightDoor = GameObject.Find ("RightDoor");
		leftExitLight = GameObject.Find ("winLightLeft");
		rightExitLight = GameObject.Find ("winLightRight");
		candleLights = GameObject.FindGameObjectsWithTag ("CandleLightTag");
		score = LevelFinishedController.instance.getNumberOfKeys ();
		numberOfPlayers = LevelFinishedController.instance.getControllers ().Count;
		fusionLight = GameObject.Find ("lightHousePointLight");
	}

	void OnGUI()
	{
		if (!LevelFinishedController.instance.isStopped())
		{
			GUI.Label (new Rect (Screen.width / 2 - 200, 40, 300, 100), "Keys to collect: " + score); 
		}
	}

	public void Score()
	{
		score--;
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
		}
		else
		{
			AudioController.instance.Play("003_CollectKey");
		}
	}

	public void PlayerParalysed()
	{
		numberOfPlayers --; 
		GameObject.Find ("MainCamera_Front").SendMessage ("StartEarthquake");
		if (numberOfPlayers == 0)
		{
			StartCoroutine(LevelFinishedController.instance.PlayerLost());
		}
	}

	public void PlayerReviwed()
	{
		numberOfPlayers ++;
	}
}
