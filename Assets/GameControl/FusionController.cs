using UnityEngine;
using System.Collections.Generic;

public class FusionController : MonoBehaviour {

	private static int closeDistance;
	private int closeDistanceConstant = 1;


	private GameObject levelController;
	private List<GameObject> players = new List<GameObject>();
	private bool fusionActivated;

	void Start () 
	{
		levelController = GameObject.Find ("LevelController");
		foreach(InputController inputController in LevelFinishedController.instance.getAllControllers())
		{
			players.Add(GameObject.Find ("Player" + inputController.getPlayerId()));
		}

		closeDistance = closeDistanceConstant + LevelFinishedController.instance.getAllControllers().Count;
	}
	
	void Update () 
	{
		if (fusionActivated)
		{
			bool finished = true;

			foreach (GameObject player in players)
			{
				float distance = Vector3.Distance(players[0].transform.localPosition, player.transform.localPosition);
				if ((finished) && (distance < closeDistance))
				{
					Vector3 direction = (players[0].transform.position - player.transform.position);
					foreach (RaycastHit hit in Physics.RaycastAll(player.transform.position, direction, distance))
					{
						if (hit.collider.tag != "Player")
						{
							finished = false;
							break;
						}
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
				AudioController.instance.Play ("026_FusionC");
				foreach(GameObject player in players)
				{
					if (player.name.Equals("Player5"))
					{
						continue;
					}
					player.rigidbody.velocity = Vector3.zero;
					player.GetComponent<PlayerController>().TriggerPlayerIdle();
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
