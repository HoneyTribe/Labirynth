using UnityEngine;
using System.Collections.Generic;

public class FusionController : MonoBehaviour {

	private static int closeDistance = 3;

	private GameObject levelController;
	private List<GameObject> players = new List<GameObject>();
	private bool fusionActivated;

	void Start () 
	{
		levelController = GameObject.Find ("LevelController");
		for (int i=1; i<=LevelFinishedController.instance.getControllers().Count; i++)
		{
			players.Add(GameObject.Find ("Player" + i));
		}
	}
	
	void Update () 
	{
		if (fusionActivated)
		{
			bool finished = true;

			foreach (GameObject player in players)
			{
				float distance = Vector3.Distance(players[0].transform.localPosition, player.transform.localPosition);
				if (distance < closeDistance)
				{
					RaycastHit hit;
					Vector3 direction = (players[0].transform.position - player.transform.position); 
					if (Physics.SphereCast(player.transform.position, 1f, direction, out hit, distance))
					{
						finished = false;
						break;
					}
				}
				else 
				{
					finished = false;
					break;
				}
			}

			if (finished)
			{
				fusionActivated = false;
				AudioController.instance.Play ("026_FusionB");
				foreach(GameObject player in players)
				{
					player.rigidbody.velocity = Vector3.zero;
				}
				levelController.gameObject.SendMessage("PlayerFinished");
			}
		}
	}

	public void ActivateFusion()
	{
		fusionActivated = true;
		foreach (GameObject player in players)
		{
			player.transform.Find("PuzzleContainer").SendMessage("ShowPuzzle");
		}
	}
}
