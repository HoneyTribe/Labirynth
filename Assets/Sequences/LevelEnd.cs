using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelEnd : MonoBehaviour
{

	public static LevelEnd instance;

	private GameObject player1;
	private GameObject camera;
	private Vector3 newCameraPosition;
	private Vector3 camTempPos;
	private Quaternion newCameraRotation;
	private static int activatedHash = Animator.StringToHash ("Activate");
	private Animator anim;
	private bool startSequence = false;
	private float camSpeed = 4.0f;
	private float playerOffsetX = -4.0f;
	private float playerOffsetY = 13.5f;
	private float playerOffsetZ = -3.0f;
	private GameObject piece1;
	private GameObject piece2;
	private GameObject piece3;
	private GameObject piece4;
	private int numberOfPlayers;
	private float closeDistance = 1.0f;

	
	void Start ()
	{
		instance = this;

		player1 = GameObject.Find ("Player1");
		camera = GameObject.Find ("MainCamera_Front");
		numberOfPlayers = LevelFinishedController.instance.getControllers().Count;
		anim = this.GetComponent<Animator>();
	
	}

	void Update()
	{
		if(startSequence == true)
		{
			camera.transform.position = Vector3.Lerp (camera.transform.position, newCameraPosition, Time.deltaTime * camSpeed);
			camera.transform.rotation = Quaternion.Lerp (camera.transform.rotation, newCameraRotation, Time.deltaTime * camSpeed);

			//if(Vector3.Distance(this.transform.position, newCameraPosition) <= closeDistance)
			//{
			//	this.anim.SetTrigger(activatedHash);
			//}

			//if(camera.transform.position == newCameraPosition)
			//{
			//	this.anim.SetTrigger(activatedHash);
			//}
		}

	}
	
	public void LevEnd()

	{
		this.transform.position = player1.transform.position;;

		camTempPos = player1.transform.position;
		camTempPos.x = player1.transform.position.x + playerOffsetX;
		camTempPos.y = player1.transform.position.y + playerOffsetY;
		camTempPos.z = player1.transform.position.z + playerOffsetZ;
		newCameraPosition = camTempPos;

		//newCameraRotation = Quaternion.Euler(70, 20, 45);
		newCameraRotation = Quaternion.Euler(55, 20, 20);
		//transform.rotation = Quaternion.Euler(50, 30, 30);

		if (numberOfPlayers == 2)
		{
			piece1 = GameObject.Find("Player1/PuzzleContainer");
			Destroy(piece1);

			piece2 = GameObject.Find("Player2/PuzzleContainer");
			Destroy(piece2);
		}
		else if (numberOfPlayers == 3)
		{
			piece1 = GameObject.Find("Player1/PuzzleContainer");
			Destroy(piece1);
			
			piece2 = GameObject.Find("Player2/PuzzleContainer");
			Destroy(piece2);

			piece3 = GameObject.Find("Player3/PuzzleContainer");
			Destroy(piece3);
		}
		else
		{
			piece1 = GameObject.Find("Player1/PuzzleContainer");
			Destroy(piece1);
			
			piece2 = GameObject.Find("Player2/PuzzleContainer");
			Destroy(piece2);
			
			piece3 = GameObject.Find("Player3/PuzzleContainer");
			Destroy(piece3);

			piece4 = GameObject.Find("Player4/PuzzleContainer");
			Destroy(piece4);
		}

		startSequence = true;
		this.anim.enabled = true;
	}
}
