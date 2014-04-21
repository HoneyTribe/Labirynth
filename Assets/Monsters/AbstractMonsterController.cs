﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractMonsterController : MonoBehaviour, StoppableObject {

	protected static Vector3 MASK = new Vector3 (1, 0, 1);
	protected static float EPSILON = 0.01f;

	protected float speed;

	private bool enter;
	protected AssemblyCSharp.Instantiation maze;
	
	private GameObject player1;
	private GameObject player2;
	private GameObject player3;
	private GameObject topLight;
	protected GameObject device;
	private PlayerController player1Controller;
	private PlayerController player2Controller;
	private PlayerController player3Controller;

	private LevelFinishedController levelFinishedController;

	protected TextMesh textMesh;

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
		player3 = GameObject.Find ("Player3");
		device = GameObject.Find ("Device");
		player1Controller = player1.GetComponent<PlayerController>();
		player2Controller = player2.GetComponent<PlayerController>();
		player3Controller = player3.GetComponent<PlayerController>();

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
		List<Vector3> players = new List<Vector3> ();
		if (!player1Controller.hasEnteredAnyMachine())
		{
			players.Add (player1.transform.position);
		}
		if (!player2Controller.hasEnteredAnyMachine())
		{
			players.Add (player2.transform.position);
		}
		if (!player3Controller.hasEnteredAnyMachine())
		{
			players.Add (player3.transform.position);
		}
		Vector3 monsterPos = transform.position;

		if (timeLeft > 0)
		{
			return device.transform.localPosition;
		}

		List<Vector3> closestPlayers = new List<Vector3> ();

		// get all inside
		foreach (Vector3 player in players)
		{
			if (maze.isInside(player))
		    {
				closestPlayers.Add (player);
			}
		}

		if (closestPlayers.Count != 0)
		{
			float dist = 100000;
			Vector3 closestPlayer = Vector3.zero;
			foreach (Vector3 player in closestPlayers)
			{
				if (maze.getDistance(monsterPos, player) < dist)
				{
					dist = maze.getDistance(monsterPos, player);
					closestPlayer = player;
				}
			}
			return closestPlayer;
		}
		else
		{
			float dist = 100000;
			Vector3 closestPlayer = Vector3.zero;
			foreach (Vector3 player in players)
			{
				if (Vector3.Distance(maze.getStart(), player) < dist)
				{
					dist = Vector3.Distance(monsterPos, player);
					closestPlayer = player;
				}
			}
			return closestPlayer;
		}
	}
}
