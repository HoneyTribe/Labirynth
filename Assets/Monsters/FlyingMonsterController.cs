using UnityEngine;
using System.Collections;

public class FlyingMonsterController : AbstractMonsterController {

	private static float updateDistance = 5.0f;
	private float prevDistance;

	public override void go () 
	{
		float distance = Vector3.Distance(transform.localPosition, newPosition);

		if ((recalculateTrigger) || (distance == 0) || (Mathf.Abs(distance - prevDistance) < EPSILON))
		{
			Vector3 targetPosition;
			if ((transform.position.x > Instantiation.planeSizeX/2) ||
				(transform.position.x < -Instantiation.planeSizeX/2))
			{
				targetPosition = new Vector3(transform.position.x - 3 * Mathf.Sign(transform.position.x),
					                         transform.position.y,
					                         transform.position.z);

			}
			else
			{
				targetPosition = getClosest(getTarget());
			}

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
			textMesh.transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
			prevDistance = 0f;
		}
		else
		{
			transform.position = Vector3.Lerp (
				transform.localPosition, newPosition, Time.deltaTime * speed / distance);
			prevDistance = distance;
		}
	}

	Vector3 getClosest(Vector3[] targets)
	{
		float dist = 100000;
		Vector3 closestTarget = Vector3.zero;
		foreach (Vector3 target in targets)
		{
			if (Vector3.Distance(transform.position, target) < dist)
			{
				dist = Vector3.Distance(transform.position, target);;
				closestTarget = target;
			}
		}

		return closestTarget;
	}
}
