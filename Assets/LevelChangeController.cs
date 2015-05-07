using UnityEngine;
using System.Collections;

public class LevelChangeController : MonoBehaviour {

	public int change;

	private TextMesh levelScreen;

	void Start ()
	{
		levelScreen = GameObject.Find ("Level").GetComponent<TextMesh> ();
	}

	void OnCollisionEnter (Collision collision)
	{
		int newLevel = LevelFinishedController.instance.getLevel () + change;
		LevelFinishedController.instance.setLevel (newLevel);
		levelScreen.text = (newLevel + 1).ToString();
	}
}
