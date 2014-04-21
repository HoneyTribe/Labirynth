using UnityEngine;
using System.Collections;

public class StandardMonsterController : AbstractMonsterController {

	private float prevDistance;

	public override void go (ref Vector3 newPosition) 
	{
		float distance = Vector3.Distance(transform.localPosition, newPosition);

		if ((recalculateTrigger) || (distance == 0) || (Mathf.Abs(distance - prevDistance) < EPSILON))
		{
			Vector3 targetPosition = getTarget();
			newPosition = maze.giveMeNextPosition(transform.localPosition, targetPosition);

			if ((maze.isInside(targetPosition)) &&
			    ((maze.transformToMazeCoordinates(targetPosition).Equals(maze.transformToMazeCoordinates(newPosition))) ||
			     (maze.transformToMazeCoordinates(targetPosition).Equals(maze.transformToMazeCoordinates(transform.localPosition)))))
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

}
