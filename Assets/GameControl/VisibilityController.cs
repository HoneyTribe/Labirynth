using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisibilityController : MonoBehaviour {

	public List<int> level;

	void Start () 
	{
		gameObject.SetActive(false);
		if (level.Contains(LevelFinishedController.instance.getLevel()))
		{
			gameObject.SetActive(true);
		}
	}
}
