using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

	private float epsilon = 0.1f;

	private float step = 0.05f;
	private bool enter;
	private AssemblyCSharp.Instantiation maze;
	
	private GameObject player1;
	private GameObject player2;
	private GameObject topLight;
	private LightController lightController;

	private TextMesh textMesh;

	private static float interval = 5f;
	private float timeLeft;


	private Vector3 newPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
	
		textMesh = gameObject.GetComponentInChildren<TextMesh> ();

		GameObject gameController = GameObject.Find ("GameController");
		maze = gameController.GetComponent<AssemblyCSharp.Instantiation>();
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		topLight = GameObject.Find ("TopLight");
		lightController = topLight.transform.parent.GetComponent<LightController>();
		enter = true;
	}
	
	void Update () {

		textMesh.text = "";
		if (timeLeft > 0)
		{
			textMesh.text = ((int) timeLeft).ToString();
			timeLeft -= Time.deltaTime;
		}

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
			if ((newPosition.Equals(Vector3.zero)) || 
			    ((Mathf.Abs(transform.localPosition.x - newPosition.x) < epsilon) && 
			 	 (Mathf.Abs(transform.localPosition.z - newPosition.z) < epsilon)))
			{
				Vector3 playerPosition = getTarget();
				newPosition = maze.giveMeNextPosition(transform.localPosition, playerPosition);
			}
			Vector3 movement = new Vector3(newPosition.x - transform.localPosition.x, 0, newPosition.z - transform.localPosition.z);
			transform.Translate(movement.normalized * step);
		}
	}

	public void setAttracted()
	{
		timeLeft = interval;
	}

	private Vector3 getTarget()
	{
		Vector3 player1Pos = player1.transform.localPosition;
		Vector3 player2Pos = player2.transform.localPosition;
		Vector3 monsterPos = transform.localPosition;

		if ((maze.isInside(player1Pos)) && (maze.isInside(player2Pos)))
		{
			// shortest distance in labirinth
			if (maze.getDistance(monsterPos, player1Pos) > maze.getDistance(monsterPos, player1Pos))
			{
				return player2Pos;
			}
			else
			{
				return player1Pos;
			}
		}
		else if ((!maze.isInside(player1Pos)) && (!maze.isInside(player2Pos)))
		{
			if (maze.isInside(monsterPos))
			{
				// shortest distance from labirinth entrance
				if (Vector3.Distance(maze.getStart(), player1Pos) > Vector3.Distance(maze.getStart(), player2Pos))
				{
					return player2Pos;
				}
				else
				{
					return player1Pos;
				}
			}
			else
			{
				// shortest distance from moster
				if (Vector3.Distance(monsterPos, player1Pos) > Vector3.Distance(monsterPos, player2Pos))
				{
					return player2Pos;
				}
				else
				{
					return player1Pos;
				}
			}
		}
		else
		{
			// Ill p1In p2In Out
			// 0   0    1    p2 
			// 0   1    0    p1
			// 1   0    1    p1
			// 1   1    0    p2
			if ((timeLeft > 0) ^ maze.isInside(player1Pos))
			{
				return player1Pos;
			}
			else
			{
				return player2Pos;
			}
		}
	}
}
