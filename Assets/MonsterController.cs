using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

	private float step = 0.05f;
	public bool enter;

	// Use this for initialization
	void Start () {
	
		enter = true;
	}
	
	void Update () {

		if (enter)
		{
			if (transform.localPosition.x < -AssemblyCSharp.Instantiation.planeSizeX/2f + 2f)
			{
				transform.Translate(step, 0, 0.02f);
			}
			else if (transform.localPosition.x > AssemblyCSharp.Instantiation.planeSizeX/2f - 2f)
			{
				transform.Translate(-step, 0, -0.02f);
			}
			else
			{
				enter = false;
			}
		}	
	}
}
