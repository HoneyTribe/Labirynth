using UnityEngine;
using System.Collections;

public class TriggerNewMaze : MonoBehaviour
{
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player"))
		{
			GameObject[] players= GameObject.FindGameObjectsWithTag ("Player");
			foreach (GameObject player in players)
			{
				player.rigidbody.velocity = Vector3.zero;
			}

			NewMazeEnding.instance.EnableNewMazeEnding();
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.Translate (0, -1.1f, 0);
		}
	}
}
