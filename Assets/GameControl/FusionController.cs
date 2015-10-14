using UnityEngine;
using System.Collections.Generic;

public class FusionController : MonoBehaviour {

	private static float closeDistance;
	private float closeDistanceConstant = 2.0f;


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

		//closeDistance = closeDistanceConstant + (LevelFinishedController.instance.getAllControllers().Count/2);

		if(LevelFinishedController.instance.getAllControllers().Count == 1)
		{
			closeDistance = 3.5f;
		}
		else if(LevelFinishedController.instance.getAllControllers().Count == 2)
		{
			closeDistance = 3.5f;
		}
		else if(LevelFinishedController.instance.getAllControllers().Count == 3)
		{
			closeDistance = 4.5f;
		}
		else
		{
			closeDistance = 4.5f;
		}
		print ("controllers: " + LevelFinishedController.instance.getAllControllers().Count);
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
					player.GetComponent<Rigidbody>().velocity = Vector3.zero;
					//player.GetComponent<PlayerController>().TriggerPlayerIdle();
					player.GetComponent<PlayerController>().TriggerPlayerHighFive();
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
