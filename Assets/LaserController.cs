using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	private static float speed = 70.0f;
	private Vector3 startPos;
	private Vector3 endPos;
	private Vector3 currentPos;

	private int shooting = -1;

	// Update is called once per frame
	void Update () 
	{
		float dist = Vector3.Distance(currentPos, endPos);
		if (shooting != -1)
		{
			currentPos = Vector3.Lerp(currentPos, endPos, Time.deltaTime * speed / dist);
			//float x = Mathf.Lerp(0, dist, Time.deltaTime * speed);
			if(currentPos != endPos)
			{
				//Vector3 pointAlongline = x * Vector3.Normalize(endPos - startPos);
				
				((LineRenderer) renderer).SetPosition(shooting, 2 * (currentPos - startPos));
			}
			else
			{
				if (shooting == 1)
				{
					shooting = 0;
					currentPos = startPos;
				}
				else
				{
				 	Destroy(gameObject);
				}
			}
		}

	}

	public void shoot (Vector3 devicePosition, Vector3 monsterPosition)
	{
		startPos = devicePosition;
		endPos = monsterPosition;
		currentPos = startPos;
		shooting = 1;
	}
}
