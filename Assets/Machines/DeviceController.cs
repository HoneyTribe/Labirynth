﻿using UnityEngine;
using System.Collections;

public class DeviceController : MonoBehaviour {

	public static DeviceController instance;
	public static float interval = 5f;
	private static int activatedHash = Animator.StringToHash ("Activate");
	private static int activatedStateHash = Animator.StringToHash ("Base Layer.Distract_Device_Activated");

	private Vector3 initialPosition;

	private Vector3 movement;
	private float time;
	private bool inLighthouse = true;
	private float speed = 65.0f;
	private int decoyCount = 0;
	private Animator anim;

	void Start () 
	{
		instance = this;
		anim = GetComponent<Animator> ();
		initialPosition = transform.position;
		movement = initialPosition;
	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance(transform.position, movement);
		if (distance > 0)
		{
			transform.position = Vector3.Lerp (
			transform.position, movement, Time.deltaTime * speed / distance);
		}

		if (time > 0)
		{
			time -= Time.deltaTime;
			if (time <= 0)
			{
				anim.SetTrigger(activatedHash);
				AudioController.instance.StopPlayingInLoop();
			}
		}
	}

	public void ShowHologram()
	{
		time = interval;
		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.nameHash != activatedStateHash)
		{
			anim.SetTrigger (activatedHash);
			AudioController.instance.PlayInLoop("024_DecoyActive");
		}
		else
		{
			anim.Play(activatedStateHash, -1, 0);
		}
	}

	public void Move(Vector3 positionToMove, Color newColor)
	{
		if (LevelFinishedController.instance.isDistractionEnabled() && !LevelFinishedController.instance.isDecoyFixed())
		{
			decoyCount++;
			if (inLighthouse)
			{
				inLighthouse = false;
				movement = new Vector3(positionToMove.x, 1, positionToMove.z);

				if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDecoyLevel
				   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.secondDecoyLevel)
				{
					FloorInstructions.instance.ChangeInstructions();
				}

				AudioController.instance.Play("001_MoveDecoyMaze");
			}
			else
			{
				inLighthouse = true;
				movement = initialPosition;

				if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDecoyLevel
				   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.secondDecoyLevel)
				{
					FloorInstructions.instance.ChangeInstructions();
				}

				AudioController.instance.Play("002_MoveDecoyBase");
			}

			foreach (Transform child in gameObject.transform)
			{
				child.gameObject.GetComponent<Renderer>().material.color = newColor;
			}
		}
	}

	public bool isDeviceInLighthouse()
	{
		return inLighthouse;
	}

	public void setMovement(Vector3 movement)
	{
		this.movement = movement;
	}

	public int getDecoyCount()
	{
		return decoyCount;
	}

}
