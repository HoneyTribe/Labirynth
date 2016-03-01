using UnityEngine;
using System.Collections;

public class LightAndDark : MonoBehaviour
{
	
	
	private bool cam1Start = false;
	private bool cam2Start = false;
	private bool cam3Start = false;
	//private bool playerStart = false;
	//private float playerSpeed = 0.2f;
	//private float mummySpeed = 0.15f;
	//private GameObject waypoint1;
	//private GameObject waypoint2;
	//private GameObject waypoint3;
	//private GameObject waypoint4;
	//private GameObject waypoint5;
	//private GameObject waypoint6;
	//private GameObject mummy1;
	//private GameObject mummy2;
	////private Transform myTransform;
	//private Transform p2Transform;
	//private Transform p3Transform;
	//private Transform p4Transform;
	//private Transform mummy1Transform;
	//private Transform mummy2Transform;
	//private Vector3 myTempPos;
	
	GameObject camera;
	Vector3 newCameraPosition1;
	Vector3 newCameraPosition2;
	Vector3 newCameraPosition3;
	Quaternion newCameraRotation1;
	Quaternion newCameraRotation2;
	Quaternion newCameraRotation3;
	
	//GameObject player2;
	//GameObject player3;
	//GameObject player4;
	
	//GameObject mmummy1;
	//GameObject mmummy2;
	
	void Start()
	{
		
		
		//waypoint1 = GameObject.Find ("Waypoint1");
		//waypoint2 = GameObject.Find ("Waypoint2");
		//waypoint3 = GameObject.Find ("Waypoint3");
		//waypoint4 = GameObject.Find ("Waypoint4");
		//waypoint5 = GameObject.Find ("Waypoint5");
		//waypoint6 = GameObject.Find ("Waypoint6");
		camera = GameObject.Find ("MainCamera_Front");
		newCameraPosition1 = new Vector3(0, 8.6f, -16.4f);
		newCameraPosition2 = new Vector3(5.76f, 14, -1);
		newCameraPosition3 = new Vector3(0, 34, -13);
		newCameraRotation1 = Quaternion.Euler(22.1f, 0, 0);
		newCameraRotation2 = Quaternion.Euler(38, 192, 1);
		newCameraRotation3 = Quaternion.Euler(70, 0, 0);
		
		//player2 = GameObject.Find ("Player2");
		//player3 = GameObject.Find ("Player3");
		// = GameObject.Find ("Player4");
		// = GameObject.Find ("Monster");
		//mummy2 = GameObject.Find ("Monster2");
		///myTransform = gameObject.transform;
		//p2Transform = player2.transform;
		//p3Transform = player3.transform;
		//p4Transform = player4.transform;
		//mummy1Transform = mummy1.transform;
		//mummy2Transform = mummy2.transform;
		
	}
	
	void Update()
	{
		if (Input.GetKeyDown("1"))
		{
			cam1Start = true;
			cam2Start = false;
			cam3Start = false;
		}
		
		if (Input.GetKeyDown("2"))
		{
			cam1Start = false;
			cam2Start = true;
			cam3Start = false;
		}
		
		if (Input.GetKeyDown("3"))
		{
			cam1Start = false;
			cam2Start = false;
			cam3Start = true;
		}
		
		if(cam1Start == true)
		{
			camera.transform.position = Vector3.Lerp (camera.transform.position, newCameraPosition1, Time.deltaTime * 0.5f);
			camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, newCameraRotation1, Time.deltaTime * 0.3f);
		}
		
		if(cam2Start == true)
		{
			camera.transform.position = Vector3.Lerp (camera.transform.position, newCameraPosition2, Time.deltaTime * 2.0f);
			camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, newCameraRotation2, Time.deltaTime * 1.2f);
		}
		
		if(cam3Start == true)
		{
			camera.transform.position = Vector3.Lerp (camera.transform.position, newCameraPosition3, Time.deltaTime * 4.0f);
			camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, newCameraRotation3, Time.deltaTime * 2.5f);
		}
	}
	
}
