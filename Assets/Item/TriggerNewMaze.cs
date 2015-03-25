using UnityEngine;
using System.Collections;

public class TriggerNewMaze : MonoBehaviour
{
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player"))
		{
			NewMazeEnding.instance.EnableNewMazeEnding();
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.Translate (0, -1.1f, 0);
		}
	}
}
