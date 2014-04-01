using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	private static float speed = 150.0f;
	private Vector3 startPos;
	private Vector3 endPos;
	private Vector3 currentPos;

	private bool shooting;

	// Update is called once per frame
	void Update () 
	{
		if (shooting)
		{
			float dist = Vector3.Distance(currentPos, endPos);
			currentPos = Vector3.Lerp(currentPos, endPos, Time.deltaTime * speed / dist);
			if(currentPos != endPos)
			{
				((LineRenderer) renderer).SetPosition(1, 2 * (currentPos - startPos));
			}
			else
			{
				shooting = false;
			}
		}
	}

	public void shoot (Vector3 startPosition, Vector3 endPosition)
	{
		startPos = startPosition;
		endPos = endPosition;
		currentPos = startPos;
		shooting = true;
	}
}
