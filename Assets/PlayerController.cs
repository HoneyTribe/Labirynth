using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;

	public float speed = 10;	

	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	private bool lighthouseEntered = false;

	private GameObject torch;
	private GameObject topLight;
	private GameObject exit;

	void Start()
	{
		torch = GameObject.Find ("LightContainer");
		topLight = GameObject.Find ("TopLight");
		exit = GameObject.Find ("Exit");
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (moveUp))
		{
			rigidbody.velocity = new Vector3(0, 0, speed);
			if (lighthouseEntered)
			{
				lighthouseEntered = false;
				topLight.gameObject.SendMessage("TurnOff");
			}
		} 
		else if (Input.GetKey (moveDown))
		{
			rigidbody.velocity = new Vector3(0, 0, -speed);
		}
		else if (Input.GetKey (moveLeft))
		{
			if (lighthouseEntered)
			{
				torch.gameObject.SendMessage("MoveLeft");
			}
			else
			{
				rigidbody.velocity = new Vector3(-speed, 0, 0);
			}
		}
		else if (Input.GetKey (moveRight))
		{
			if (lighthouseEntered)
			{
				torch.gameObject.SendMessage("MoveRight");
			}
			else
			{
				rigidbody.velocity = new Vector3(speed, 0, 0);
			}
		}
		else 
		{
			rigidbody.velocity = new Vector3(0, 0, 0);
		}

		/*if (Input.GetKey (moveUp))
		{
			moveDirection = new Vector3(0, 0, 1);
		} 
		else if (Input.GetKey (moveDown))
		{
			moveDirection = new Vector3(0, 0, -1);
		}
		else if (Input.GetKey (moveLeft))
		{
			moveDirection = new Vector3(-1, 0, 0);
		}
		else if (Input.GetKey (moveRight))
		{
			moveDirection = new Vector3(1, 0, 0);
		}
		else 
		{
			moveDirection = new Vector3(0, 0, 0);
		}


		//moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		controller.Move(moveDirection * Time.deltaTime);*/
	}

	void OnCollisionEnter (Collision collision)
	{
		if(collision.collider.name == "Lighthouse")
		{
			lighthouseEntered = true;
			topLight.gameObject.SendMessage("TurnOn");
		}
		if(collision.collider.name == "ExitTrigger")
		{
			Destroy(gameObject);
			exit.gameObject.SendMessage("PlayerFinished");
		}
	}
}
