using UnityEngine;
using System.Collections;

public class FusionController : MonoBehaviour {

	private static int closeDistance = 3;

	private GameObject levelController;
	private GameObject player1;
	private GameObject player2;

	private bool fusionActivated;

	void Start () 
	{
		levelController = GameObject.Find ("LevelController");
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
	}
	
	void Update () 
	{
		if (fusionActivated)
		{
			if (Vector3.Distance(player1.transform.localPosition, player2.transform.localPosition) < closeDistance)
			{
				fusionActivated = false;
				player1.rigidbody.velocity = Vector3.zero;
				player2.rigidbody.velocity = Vector3.zero;
				levelController.gameObject.SendMessage("PlayerFinished");
			}
		}
	}

	public void ActivateFusion()
	{
		fusionActivated = true;
	}
}
