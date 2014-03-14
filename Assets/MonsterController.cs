using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

	private float epsilon = 0.1f;

	private float step = 0.05f;
	private bool enter;
	private AssemblyCSharp.Instantiation maze;
	
	private GameObject player1;
	private GameObject player2;

	private Vector3 newPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
	
		GameObject gameController = GameObject.Find ("GameController");
		maze = gameController.GetComponent<AssemblyCSharp.Instantiation>();
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		enter = true;
	}
	
	void Update () {

		if (enter)
		{
			if (transform.localPosition.x < -AssemblyCSharp.Instantiation.planeSizeX/2f + 2f)
			{
				transform.Translate(step, 0, 0.02f);
			}
			else if (transform.localPosition.x > AssemblyCSharp.Instantiation.planeSizeX/2f - 2f)
			{
				transform.Translate(-step, 0, -0.02f);
			}
			else
			{
				enter = false;
			}
		}	
		else
		{
			// track always player1 for simplicity
			Vector3 playerPosition = player1.transform.localPosition;

			if ((newPosition.Equals(Vector3.zero)) || 
			    ((Mathf.Abs(transform.localPosition.x - newPosition.x) < epsilon) && 
			 	 (Mathf.Abs(transform.localPosition.z - newPosition.z) < epsilon)))
			{
				newPosition = maze.giveMeNextPosition(transform.localPosition, playerPosition);
			}
			Vector3 movement = new Vector3(newPosition.x - transform.localPosition.x, 0, newPosition.z - transform.localPosition.z);
			transform.Translate(movement.normalized * step);
		}
	}
}
