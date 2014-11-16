using UnityEngine;
using System.Collections;

public class VisibilityController : MonoBehaviour {

	public int level;

	void Start () 
	{
		gameObject.SetActive(false);
		if (LevelFinishedController.instance.getLevel() == level - 1)
		{
			gameObject.SetActive(true);
		}
	}
}
