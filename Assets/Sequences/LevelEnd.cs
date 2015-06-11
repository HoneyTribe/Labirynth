using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelEnd : MonoBehaviour
{

	public static LevelEnd instance;

	private GameObject player1;
	GameObject camera;
	Vector3 newCameraPosition;
	Quaternion newCameraRotation;

	// Use this for initialization
	void Start ()
	{
		instance = this;

		player1 = GameObject.Find ("Player1");
		camera = GameObject.Find ("MainCamera_Front");
	
	}
	
	public void LevEnd()

	{
		//player1.transform.position = new Vector3(0,0,0);
		//newCameraPosition = player1.transform.position;
		//camera.transform.position = Vector3.Lerp (camera.transform.position, newCameraPosition, Time.deltaTime * 4f);
	}
}
