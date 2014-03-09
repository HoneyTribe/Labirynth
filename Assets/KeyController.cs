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
		Destroy(gameObject);
		gameController.gameObject.SendMessage("Score");
	}
}
