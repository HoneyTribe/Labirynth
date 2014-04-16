using UnityEngine;
using System.Collections;

public class FlyingMonsterController : AbstractMonsterController {

	private static float updateDistance = 5.0f;

	public override void go (ref Vector3 newPosition) 
	{
		float distance = Vector3.Distance(transform.localPosition, newPosition) - EPSILON;

		if ((recalculateTrigger) || (distance <= 0))
		{
			Vector3 targetPosition = getTarget();
			if (Vector3.Distance(transform.localPosition, targetPosition) > updateDistance)
			{
				newPosition = transform.localPosition +
							  new Vector3(targetPosition.x - transform.localPosition.x,
				                          0,
					            		  targetPosition.z - transform.localPosition.z).normalized * updateDistance;
			}
			else
			{
				newPosition = targetPosition;
				newPosition.y = transform.localPosition.y;
			}
			transform.rotation = Quaternion.LookRotation(newPosition - transform.localPosition);
		}
		else
		{
			transform.position = Vector3.Lerp (
				transform.localPosition, newPosition, Time.deltaTime * speed / distance);
		}
	}
}
