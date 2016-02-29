using UnityEngine;
using System.Collections;

public class Menu1 : MonoBehaviour
{
	

	private bool camStart = false;
	private bool cam2Start = false;
	private bool cam3Start = false;
	private bool playerStart = false;
	private float playerSpeed = 0.2f;
	private float mummySpeed = 0.15f;
	private GameObject waypoint1;
	private GameObject waypoint2;
	private GameObject waypoint3;
	private GameObject waypoint4;
	private GameObject waypoint5;
	private GameObject waypoint6;
	private GameObject mummy1;
	private GameObject mummy2;
	private Transform myTransform;
	private Transform p2Transform;
	private Transform p3Transform;
	private Transform p4Transform;
	private Transform mummy1Transform;
	private Transform mummy2Transform;
	private Vector3 myTempPos;

	GameObject camera;
	Vector3 newCameraPosition;
	Vector3 newCameraPosition2;
	Vector3 newCameraPosition3;
	Quaternion newCameraRotation;
	Quaternion newCameraRotation2;

	GameObject player2;
	GameObject player3;
	GameObject player4;

	GameObject mmummy1;
	GameObject mmummy2;
	
	void Start()
	{


		waypoint1 = GameObject.Find ("Waypoint1");
		waypoint2 = GameObject.Find ("Waypoint2");
		waypoint3 = GameObject.Find ("Waypoint3");
		waypoint4 = GameObject.Find ("Waypoint4");
		waypoint5 = GameObject.Find ("Waypoint5");
		waypoint6 = GameObject.Find ("Waypoint6");
		camera = GameObject.Find ("MainCamera_Front");
		newCameraPosition = new Vector3(0, 5, -21);
		newCameraPosition2 = new Vector3(0, 25, -100);
		newCameraPosition3 = new Vector3(0, 5, 8);
		newCameraRotation = Quaternion.Euler(0, 0, 0);
		newCameraRotation2 = Quaternion.Euler(70, 0, 0);

		player2 = GameObject.Find ("Player2");
		player3 = GameObject.Find ("Player3");
		player4 = GameObject.Find ("Player4");
		mummy1 = GameObject.Find ("Monster");
		mummy2 = GameObject.Find ("Monster2");
		myTransform = gameObject.transform;
		p2Transform = player2.transform;
		p3Transform = player3.transform;
		p4Transform = player4.transform;
		mummy1Transform = mummy1.transform;
		mummy2Transform = mummy2.transform;
		
	}
	
	void Update()
	{
		if (Input.GetKeyDown("1"))
		{
			camStart = true;
		}

		if (Input.GetKeyDown("2"))
		{
			playerStart = true;
		}

		if (Input.GetKeyDown("3"))
		{
			cam2Start = true;
			camStart = false;
		}

		if (Input.GetKeyDown("4"))
		{
			cam3Start = true;
			cam2Start = false;
		}

		if(camStart == true)
		{
			camera.transform.position = Vector3.Lerp (camera.transform.position, newCameraPosition, Time.deltaTime/2);
			camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, newCameraRotation, Time.deltaTime/3);
		}

		if(cam2Start == true)
		{
			camera.transform.position = Vector3.Lerp (camera.transform.position, newCameraPosition2, Time.deltaTime * 2.0f);
			camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, newCameraRotation2, Time.deltaTime * 1.2f);
		}

		if(cam3Start == true)
		{
			camera.transform.position = Vector3.Lerp (camera.transform.position, newCameraPosition3, Time.deltaTime * 4.0f);
			camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, newCameraRotation, Time.deltaTime * 2.5f);
		}

		if(playerStart == true)
		{
			myTransform.position = Vector3.Lerp(myTransform.position, waypoint1.transform.position, Time.deltaTime * playerSpeed);
			p2Transform.position = Vector3.Lerp(p2Transform.position, waypoint2.transform.position, Time.deltaTime * playerSpeed);
			p3Transform.position = Vector3.Lerp(p3Transform.position, waypoint3.transform.position, Time.deltaTime * playerSpeed);
			p4Transform.position = Vector3.Lerp(p4Transform.position, waypoint4.transform.position, Time.deltaTime * playerSpeed);
			mummy1Transform.position = Vector3.Lerp(mummy1Transform.position, waypoint5.transform.position, Time.deltaTime * mummySpeed);
			mummy2Transform.position = Vector3.Lerp(mummy2Transform.position, waypoint6.transform.position, Time.deltaTime * mummySpeed);

		}
	}
	
}
