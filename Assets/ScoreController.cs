using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	private int score;

	private GameObject leftDoor;
	private GameObject rightDoor;
	private GameObject leftExitLight;
	private GameObject rightExitLight;
	private GameObject[] candleLights;
	private LevelFinishedController levelFinishedController;
	private GameObject fusionLight;
	
	void Start()
	{ 
		leftDoor = GameObject.Find ("LeftDoor");
		rightDoor = GameObject.Find ("RightDoor");
		leftExitLight = GameObject.Find ("winLightLeft");
		rightExitLight = GameObject.Find ("winLightRight");
		candleLights = GameObject.FindGameObjectsWithTag ("CandleLightTag");
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController>();
		score = levelFinishedController.getNumberOfKeys ();
		fusionLight = GameObject.Find ("lightHousePointLight");
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 200, 40, 300, 100), "Keys to collect: " + score); 
	}

	public void Score()
	{
		score--;
		if (score == 0)
		{
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
		}
	}
}
