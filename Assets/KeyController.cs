using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	private GameObject gameController;

	void Start()
	{
		gameController = GameObject.Find ("GameController");
	}
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.collider.name != "Monster")
		{
			Destroy(gameObject);
			gameController.gameObject.SendMessage("Score");
		}
	}
}
