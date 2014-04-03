using UnityEngine;
using System.Collections;

public class FlyingMonsterController : AbstractMonsterController {

	private static float updateDistance = 5.0f;

	private bool direction;

	public override void go (ref Vector3 newPosition, bool attractionTrigger) 
	{

		float distance = Vector3.Distance(transform.localPosition, newPosition);

		if ((attractionTrigger) || (distance == 0))
		{
			Vector3 playerPosition = getTarget();
			if (direction) // horisontal
			{
				newPosition = new Vector3(calculateStep(transform.localPosition.x, playerPosition.x),
				                          transform.localPosition.y,
				                          transform.localPosition.z);
				direction = false;
			}
			else
			{
				newPosition = new Vector3(transform.localPosition.x, 
				                          transform.localPosition.y, 
				                          calculateStep(transform.localPosition.z, playerPosition.z));
				direction = true;
			}
		}
		else
		{
			transform.position = Vector3.Lerp (
				transform.localPosition, newPosition, Time.deltaTime * speed / distance);
		}
	}

	private float calculateStep(float currentPos, float playerPos)
	{
		if(Mathf.Abs(playerPos - currentPos) > updateDistance)
		{
			return currentPos + Mathf.Sign(playerPos - currentPos) * updateDistance;
		}
		else
		{
			return playerPos;
		}		
	}
}
