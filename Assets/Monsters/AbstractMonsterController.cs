using UnityEngine;
using System.Collections;

public abstract class AbstractMonsterController : MonoBehaviour, StoppableObject {

	protected static Vector3 MASK = new Vector3 (1, 0, 1);
	protected static float EPSILON = 0.01f;

	protected float speed;

	private bool enter;
	protected AssemblyCSharp.Instantiation maze;
	
	private GameObject player1;
	private GameObject player2;
	private GameObject topLight;
	protected GameObject device;
	private PlayerController player1Controller;
	private PlayerController player2Controller;

	private LevelFinishedController levelFinishedController;

	private TextMesh textMesh;

	private static float interval = 5f;
	private float timeLeft;
	protected bool recalculateTrigger;

	private Vector3 newPosition;

	private bool monsterStopped;

	public abstract void go (ref Vector3 newPosition);

	void Start () {
	
		textMesh = gameObject.GetComponentInChildren<TextMesh> ();

		GameObject gameController = GameObject.Find ("GameController");
		maze = gameController.GetComponent<AssemblyCSharp.Instantiation>();
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		device = GameObject.Find ("Device");
		player1Controller = player1.GetComponent<PlayerController>();
		player2Controller = player2.GetComponent<PlayerController>();

		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController>();

		enter = true;
		recalculateTrigger = false;
	}

	void Update () {

		if (levelFinishedController.isStopped())
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			return;
		}

		textMesh.text = "";
		if (timeLeft > 0)
		{
			if (timeLeft == interval)
			{
				recalculateTrigger  = true;
			}
			timeLeft -= Time.deltaTime;
			device.renderer.materials[0].color=Color.white;
			textMesh.text = ((int) (timeLeft + 1)).ToString();
			if (timeLeft <= 0)
			{
				recalculateTrigger = true;
				device.renderer.materials[0].color=Color.grey;
			}
		}

		if (enter)
		{
			if (transform.localPosition.x < -AssemblyCSharp.Instantiation.planeSizeX/2f + 2f)
			{
				transform.Translate(0.08f, 0, 0.02f);
			}
			else if (transform.localPosition.x > AssemblyCSharp.Instantiation.planeSizeX/2f - 2f)
			{
				transform.Translate(-0.08f, 0, -0.02f);
			}
			else
			{
				newPosition = transform.localPosition;
				enter = false;
			}
		}	
		else
		{
			if (!monsterStopped)
			{
				go (ref newPosition);
			}
		}
		recalculateTrigger = false;
	}

	public void setStopped(bool monsterStopped)
	{
		this.monsterStopped = monsterStopped;
		if (!monsterStopped)
		{
			recalculateTrigger = true;
		}
	}

	public void setAttracted()
	{
		timeLeft = interval;
	}

	public void setSpeed(float speed)
	{
		this.speed = speed * LevelFinishedController.instance.gameSpeed;
	}

	protected Vector3 getTarget()
	{
		Vector3 player1Pos = player1.transform.position;
		Vector3 player2Pos = player2.transform.position;
		Vector3 monsterPos = transform.position;

		if (timeLeft > 0)
		{
			return device.transform.localPosition;

		}


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
				// skip lighthouse guy
				if (player1Controller.hasEnteredLighthouse())
				{
					return player2Pos;
				}

				if (player2Controller.hasEnteredLighthouse())
				{
					return player1Pos;
				}
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
			if (maze.isInside(player1Pos))
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
