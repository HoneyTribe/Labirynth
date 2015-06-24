using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TriggerNewMaze : MonoBehaviour
{
	private GameObject drone;

	void Start()
	{
		if(LevelFinishedController.instance.isTeleportEnabled() == true || LevelFinishedController.instance.isStunGunEnabled() == true )
		{
			drone = GameObject.Find ("Drone");
		}
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player"))
		{
			GameObject[] players= GameObject.FindGameObjectsWithTag ("Player");
			foreach (GameObject player in players)
			{
				player.rigidbody.velocity = Vector3.zero;
			}

			if(LevelFinishedController.instance.isTeleportEnabled() == true || LevelFinishedController.instance.isStunGunEnabled() == true )
			{
				drone.rigidbody.velocity = Vector3.zero;
			}

			NewMazeEnding.instance.EnableNewMazeEnding();
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.Translate (0, -1.1f, 0);
		}
	}
}
