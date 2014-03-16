using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public static int numberOfKeys = 2;
	private int score = 0;

	private GameObject leftDoor;
	private GameObject rightDoor;
	private GameObject leftExitLight;
	private GameObject rightExitLight;
	private GameObject[] candleLights;
	
	void Start()
	{ 
		leftDoor = GameObject.Find ("LeftDoor");
		rightDoor = GameObject.Find ("RightDoor");
		leftExitLight = GameObject.Find ("winLightLeft");
		rightExitLight = GameObject.Find ("winLightRight");
		candleLights = GameObject.FindGameObjectsWithTag ("CandleLightTag");
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 200, 20, 300, 100), "Keys: " + score); 
	}

	public void Score()
	{
		score++;
		if (score == numberOfKeys)
		{
			leftDoor.gameObject.SendMessage("OpenDoor");
			rightDoor.gameObject.SendMessage("OpenDoor");
			leftExitLight.gameObject.SendMessage("TurnLightOn");
			rightExitLight.gameObject.SendMessage("TurnLightOn");
			foreach (GameObject light in candleLights)
			{
				light.gameObject.SendMessage("TurnLightOn");
			}
		}
	}
}
