using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TriggerNewMaze : MonoBehaviour
{
	private GameObject drone;
	private bool pushed = false;

	void Start()
	{
		if(LevelFinishedController.instance.isTeleportEnabled() == true || LevelFinishedController.instance.isStunGunEnabled() == true )
		{
			drone = GameObject.Find ("Drone");
		}
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if (((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player")) && (!pushed))
		{
			pushed = true;
			GameObject[] players= GameObject.FindGameObjectsWithTag ("Player");
			foreach (GameObject player in players)
			{
				player.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}

			if(LevelFinishedController.instance.isTeleportEnabled() == true || LevelFinishedController.instance.isStunGunEnabled() == true )
			{
				drone.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}

			NewMazeEnding.instance.EnableNewMazeEnding();
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.Translate (0, 0, -0.8f);
		}
	}
}
