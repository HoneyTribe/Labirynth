using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	private GameObject gameController;

	void Start()
	{
		gameController = GameObject.Find ("GameController");
	}
	
	void OnTriggerEnter (Collider currentCollider)
	{
		if ((currentCollider.tag == "Player") && (!currentCollider.gameObject.GetComponent<PlayerController>().isParalysed()))
		{
			Destroy(gameObject.transform.parent.gameObject);
			gameController.gameObject.SendMessage("Score");
		}
	}
}
